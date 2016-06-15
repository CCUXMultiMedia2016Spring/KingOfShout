using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KingOfShout
{
    public partial class Form1 : Form
    {
        private KingOfShoutBackend game;
        private Form2 inGame;
        public Form1()
        {
            InitializeComponent();
            game = new KingOfShoutBackend();
            ConnectionWorker.WorkerReportsProgress = true;
            ConnectionWorker.WorkerSupportsCancellation = true;
            ConnectionWorker.ProgressChanged += 
                new ProgressChangedEventHandler(ConnectionWorker_ProgressChanged);

            textBox_IPaddress.Text = "127.0.0.1";

            this.Panel_Ingame.Hide();
            this.Panel_Result.Hide();

        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            if(game.user.isRegistered&&game.connection.isConnected)
            {
                game.Start();
            }
        }      

        private void Register_Button_Click(object sender, EventArgs e)
        {
            
            game.user.Register(this.textBox_UserName.Text);
            this.textBox_UserName.ReadOnly = true;
        }

        private void IP_Button_Click(object sender, EventArgs e)
        {
            if (game.user.isRegistered && !game.connection.isConnected)
            {
                if (game.connection.ConnectTo(this.textBox_IPaddress.Text))
                {
                    if (this.ConnectionWorker.IsBusy != true)
                    {
                        this.ConnectionWorker.RunWorkerAsync();
                    }
                    this.textBox_IPaddress.ReadOnly = true;
                    this.Label_IPalert.Text = "Connected";
                }
                else
                {
                    this.Label_IPalert.Text = "Connection error";
                }
            }
            else if (game.connection.isConnected)
            {
                this.Label_IPalert.Text = "Already connnect, click start to play game";
            }else
            {
                this.Label_IPalert.Text = "Register First";
            }
        }

        private void ConnectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            KingOfShoutBackend.Connection connection = game.connection;
            
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
                    Console.WriteLine("Server>> {0}",response);
                    if (response == "hello")
                    {
                        worker.ReportProgress(0, "hello");
                    }else if(response == "register")
                    {
                        connection.SendData(this.game.user.name);
                        worker.ReportProgress(1, "registered");
                    }else if(response == "gamestart")
                    {
                        this.Panel_IPaddress.Hide();
                        this.Panel_NameRegister.Hide();
                        this.Panel_Menu.Hide();
                        this.Title.Hide();
                        this.Width = 648;
                        this.Height = 545;
                        this.Panel_Ingame.Show();
                        
                        connection.SendData("margin");
                        worker.ReportProgress(2, "gamestart");
                    }else if(response == "attack")
                    {
                        worker.ReportProgress(2, "attack");
                        int myhp = int.Parse(connection.Recieve());
                        int ophp = int.Parse(connection.Recieve());
                        this.Textbox_debug.AppendText(string.Format("Attack!!!,MyHP:{0},BadguyHP:{1}", myhp, ophp));
                    }else if(response == "attacked")
                    {
                        worker.ReportProgress(3, "attacked");
                        int ophp = int.Parse(connection.Recieve());
                        int myhp = int.Parse(connection.Recieve());
                        this.Textbox_debug.AppendText(string.Format("Attacked!!!!,MyHP:{0},BadguyHP:{1}", myhp, ophp));
                    }
                }
            }
        }// End of Connection Worker

        private void ConnectionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("ClientState>>{0}", e.UserState);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectionWorker.CancelAsync();
            game.connection.Disconnect();
        }

        private void Button_Attack_Click(object sender, EventArgs e)
        {
            game.connection.SendData("9");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.connection.Disconnect();
        }
    }

    public class KingOfShoutBackend
    {
        public class User
        {
            public bool isRegistered;
            public string name;
            public int hp;

            public User()
            {
                this.hp = 100;
                this.isRegistered = false;
                this.name = "";
            }

            public void Register(string name)
            {
                this.name = name;
                this.isRegistered = true;
            }
        }

        public class Connection
        {
            public bool isConnected;
            private TcpClient client;
            private NetworkStream stream;
            private const int PORT = 9999;
            private const int BUFFER = 1024;
            private Byte[] data;

            public Connection()
            {
                this.isConnected = false;
            }

            public bool ConnectTo(string ip)
            {
                try
                {
                    client = new TcpClient(ip, PORT);
                    stream = client.GetStream();
                    this.isConnected = true;
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public void SendData(string message)
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);
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
        }

        public User user;
        public Connection connection;

        public KingOfShoutBackend()
        {
            user = new User();
            connection = new Connection();   
        }

        public void Start()
        {
            this.connection.SendData("start");
           /*RetriveQuestion();
            Recognition();
            SendBackScore();
            SendFinal();

            RecieveAttack();
            RecieveFinal();*/
        }
    }
}
