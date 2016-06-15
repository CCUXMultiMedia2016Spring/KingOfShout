using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Diagnostics;

public class Client
{

    private TcpClient _client;
    private NetworkStream _stream;
    private Receiver _receiver;
    private Sender _sender;
    private const int PORT = 9999;

    public void SendData(string message)
    {
        _sender.SendData(message);
    }

    // Consumers register to receive data.
    public event EventHandler<DataReceivedEventArgs> DataReceived;

    public Client()
    {

    }

    public void Start(string ip)
    {
        _client = new TcpClient(ip, PORT);
        _stream = _client.GetStream();

        _receiver = new Receiver(_stream);
        _sender = new Sender(_stream);

        _receiver.DataReceived += OnDataReceived;
    }

    private void OnDataReceived(object sender, DataReceivedEventArgs e)
    {
        var handler = DataReceived;
        if (handler != null) DataReceived(this, e);  // re-raise event
    }

    public void Recieve()
    {
        const int BUFFERSIZE = 1024;
        Byte[] data = new Byte[BUFFERSIZE];
        string responseData = String.Empty;
        Int32 bytes = _stream.Read(data, 0, data.Length);
        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        Console.WriteLine("Received: {0}", responseData);
    }


   
    private sealed class Receiver
    {
        internal event EventHandler<DataReceivedEventArgs> DataReceived;

        private NetworkStream _stream;
        private Thread _thread;
        private Byte[] data;
        private const int BUFFERSIZE = 1024;
        private string responseData;

        internal Receiver(NetworkStream stream)
        {
            _stream = stream;
            data = new Byte[BUFFERSIZE];
            responseData = String.Empty;

            _thread = new Thread(Run);
            _thread.Start();
        }

        private void Run()
        {
            // main thread loop for receiving data...
            
        }

        
    }

    private sealed class Sender
    {

        private NetworkStream _stream;
        private Thread _thread;

        internal void SendData(string message)
        {
            // transition the data to the thread and send it...
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            _stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);
        }

        internal Sender(NetworkStream stream)
        {
            _stream = stream;
            _thread = new Thread(Run);
            _thread.Start();
        }

        private void Run()
        {
            // main thread loop for sending data...
        }

        
    }

}