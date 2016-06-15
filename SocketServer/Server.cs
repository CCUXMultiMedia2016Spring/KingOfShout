using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace SocketServer
{
    class MyTcpListener
    {
        public static List<Thread> connections;

        static MyTcpListener()
        {
            connections = new List<Thread>();
        }

        public void Start()
        {
            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 9999;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Matchmacking thread
                BackgroundWorker matchmacking = new BackgroundWorker();
                matchmacking.WorkerReportsProgress = true;
                matchmacking.DoWork += new DoWorkEventHandler(MatchMaker.Match);
                matchmacking.ProgressChanged += new ProgressChangedEventHandler(MatchMaker.FoundMatch);
                matchmacking.RunWorkerAsync();

                // Enter the listening loop.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();

                    // Start new Thread to handle
                    Console.WriteLine("New Client Connected!");
                    Thread qq = new Thread(() => MatchMaker.AppendClient(client));
                    qq.Start();
                    qq.Join();
                    MyTcpListener.connections.Add(qq);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }

        public void ServerStatus()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.Write("Current Registerd Player: ");
                foreach (var player in MatchMaker.clients)
                {
                    Console.Write(player.name + " ");
                }
                Console.WriteLine();

                Console.Write("Current Pending Player: ");
                foreach (var player in MatchMaker.clients)
                {
                    if (player.status == (int)GameClient.StatusList.pending)
                    {
                        Console.Write(player.name);
                    }
                }
                Console.WriteLine();
            }
        }
    }// End of MyTCPListener

    class MatchMaker
    {
        public static List<GameClient> clients;
        public static List<Thread> gameRoom;
        public static int pendingPlayer;

        static MatchMaker()
        {
            pendingPlayer = 0;
            gameRoom = new List<Thread>();
            clients = new List<GameClient>();
        }

        public static void AppendClient(TcpClient client)
        {
            GameClient player = new GameClient(client);
            clients.Add(player);

            Console.WriteLine("Name  :  Status");
            foreach (var pla in MatchMaker.clients)
            {
                Console.WriteLine("{0}  :  {1}", pla.name, pla.status);
            }

            Console.WriteLine("Current registered player: ");
            foreach(var p in MatchMaker.clients)
            {
                Console.WriteLine(p.name);
            }
            Console.WriteLine();
        }

        // Background worker do (Find pair of player)
        public static void Match(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                Thread.Sleep(0);
                if (MatchMaker.pendingPlayer > 1)
                {
                    MatchMaker.pendingPlayer -= 2;
                    Console.WriteLine("In worker" + MatchMaker.pendingPlayer.ToString());
                    worker.ReportProgress(1, "foundpair");
                }
            }
        }// End of Match()

        // Background logic raise event <Match>(found pair) 
        public static void FoundMatch(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("Found pair");
            int indexp1 = -1;
            int indexp2 = -1;
            foreach (var p in MatchMaker.clients)
            {
                if (indexp1 == -1 || indexp2 == -1 )
                {
                    if (p.status == (int)GameClient.StatusList.pending)
                    {
                        Console.WriteLine("Pending");
                        if (indexp1 == -1) { indexp1 = MatchMaker.clients.IndexOf(p); }
                        else { indexp2 = MatchMaker.clients.IndexOf(p); }
                    }
                }
                else
                {
                    break;
                }
            }
            MatchMaker.StartGame(indexp1, indexp2);
        }

        public static void StartGame(int indexp1, int indexp2)
        {
            GameClient p1 = MatchMaker.clients[indexp1];
            GameClient p2 = MatchMaker.clients[indexp2];
            Console.WriteLine("Start game for {0} vs {1}", p1.name, p2.name);

            // TODO: Consider to use background worker instead of thread. Risk of losing GameDealer after <GameDealer>.(Deal) is done
            // TODO: Thread may effect multiple gameroom funciton.
            GameDealer qq = new GameDealer();
            qq.Deal(p1, p2);
        }
        
    }// End of class MatchMaker

    class GameDealer
    {
        GameClient p1;
        GameClient p2;
        BackgroundWorker PlayerOneReciever; // Recieve player one attack number
        BackgroundWorker PlayerTwoReciever; // Recieve player two attack number

        public void Deal(GameClient p1, GameClient p2)
        {
            GameDealer dealer = new GameDealer();
            dealer.p1 = p1;
            dealer.p2 = p2;
            dealer.GameStart();
        }

        private void Broadcast(string message)
        {
            p1.connection.SendData(message);
            p2.connection.SendData(message);
        }

        private void GameStart()
        {
            InitializePlayerStatus();
            InitializePlayerRecievers();
            Broadcast("gamestart");
        }

        private void InitializePlayerRecievers()
        {
            // Build reciever for both player
            PlayerOneReciever = new BackgroundWorker();
            PlayerOneReciever.WorkerReportsProgress = true;
            PlayerOneReciever.DoWork += new DoWorkEventHandler(this.HandleRecievedData);
            PlayerOneReciever.ProgressChanged += new ProgressChangedEventHandler(this.onDataRecieved);

            PlayerTwoReciever = new BackgroundWorker();
            PlayerTwoReciever.WorkerReportsProgress = true;
            PlayerTwoReciever.DoWork += new DoWorkEventHandler(this.HandleRecievedData);
            PlayerTwoReciever.ProgressChanged += new ProgressChangedEventHandler(this.onDataRecieved);

            // Start the BGworker
            PlayerOneReciever.RunWorkerAsync(p1);
            PlayerTwoReciever.RunWorkerAsync(p2);
        }

        private void InitializePlayerStatus()
        {
            p1.hp = 100;
            p1.opponent = p2;
            p2.hp = 100;
            p2.opponent = p1;
        }

        private void HandleRecievedData(object sender, DoWorkEventArgs e)
        {
            GameClient player = (GameClient)e.Argument;
            BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {
                string attack = player.connection.Recieve();
                Console.WriteLine("ATTACK{0}", attack);
                string[] msg = new string[2] { player.name, attack };
                worker.ReportProgress(3, msg);
            }
        }

        private void onDataRecieved(object sender, ProgressChangedEventArgs e)
        {
            GameClient player;
            string[] msg = e.UserState as string[];
            if (msg[0] == this.p1.name)
            { player = this.p1; }
            else
            { player = this.p2; }
            string damage = msg[1];
            Console.WriteLine(msg);
            Console.WriteLine(player.name);
            Console.WriteLine(damage);
            /*
            player.opponent.hp -= int.Parse(damage);
            player.connection.SendData("attack");
            player.connection.SendData(player.hp.ToString());
            player.connection.SendData(player.opponent.hp.ToString());
            player.opponent.connection.SendData("attacked");
            player.opponent.connection.SendData(player.hp.ToString());
            player.opponent.connection.SendData(player.opponent.hp.ToString());*/
            Console.WriteLine("Player:{0} has attacked Player:{1}, damage:{2}",player.name,player.opponent.name,damage);
        }
    }
    
    class GameClient
    {
        public enum StatusList { onHold, pending, inGame};
        public Connection connection;
        public string name;
        public int status;
        public int hp;
        public GameClient opponent;
        public BackgroundWorker reciever;

        public GameClient(TcpClient s)
        {
            this.status = (int)StatusList.onHold;
            reciever = new BackgroundWorker();
            reciever.WorkerReportsProgress = true;
            reciever.WorkerSupportsCancellation = true;
            reciever.DoWork += new DoWorkEventHandler(Reciever);
            reciever.ProgressChanged += new ProgressChangedEventHandler(data_received);
            this.connection = new Connection(s);
            this.RequestRegister();
            reciever.RunWorkerAsync();
        }

        private void data_received(object sender, ProgressChangedEventArgs e) {
            Console.WriteLine(e.UserState);
        }
        public void Reciever(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            Connection connection = this.connection;

            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    string response = connection.Recieve();
                    string msg = String.Format("Client>>{0}>>{1}", name, response);
                    if (response == "start")
                    {
                        this.status = (int)StatusList.pending;
                        MatchMaker.pendingPlayer += 1;
                        worker.ReportProgress(0, msg);
                    }                    
                }
            }
        }
        public void RequestRegister()
        {
            this.connection.SendData("register");
            string response = this.connection.Recieve();
            this.name = response;
            Console.WriteLine("New user registered : {0}", this.name);
        }
    }// End of GameCLient

    public class Connection
    {
        private TcpClient client;
        private NetworkStream stream;
        private const int BUFFER = 1024;
        private Byte[] data;

        public Connection(TcpClient s)
        {
            this.client = s;
            this.stream = s.GetStream();
        }

        public void SendData(string message)
        {
            try {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
            }
            catch
            {
                
            }
        }

        public string Recieve()
        {
            // Buffer to store the response bytes.
            data = new Byte[BUFFER];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            return responseData;
        }

        public void Disconnect()
        {
            stream.Close();
            client.Close();
        }
    }// End of Connection

    /*
    // State object for reading client data asynchronously

    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    class Server
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private const int port = 9999;        

        public void Start()
        {
            StartListen();
        }

        private static void StartListen()
        {
            Console.WriteLine("Server, Hello");
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            IPEndPoint localIP = new IPEndPoint(IPAddress.Any, port);
            try
            {
                listener.Bind(localIP);
                listener.Listen(4);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(OnConnection),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void OnConnection(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        private static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket. 
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                        content.Length, content);
                    // Echo the data back to the client.
                    Send(handler, content);
                    Thread.Sleep(2000);
                    Send(handler, content);
                    Thread.Sleep(2000);
                    Send(handler, content);
                }
                else {
                    // Not all data received. Get more.
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }// End of ReadCallback

        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                /*
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }*/
}
