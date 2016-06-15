using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using SocketServer;

namespace SocketServer
{
    public class demoServer
    {
        public static void Main()
        {
            MyTcpListener server = new MyTcpListener();
            server.Start();
        }
    }
}