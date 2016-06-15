using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    class demoClient
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Start();
        }
    }
}
