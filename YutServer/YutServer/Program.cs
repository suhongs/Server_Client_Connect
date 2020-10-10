using System;
using UnityNetwork;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace YutServer
{
    class Program
    {

        static void Main(string[] args)
        {
            Server ser = new Server();
            ser.m_thread = new Thread(new ThreadStart(ser.RUN));
            ser.m_thread.Start();
        }
    }
}
