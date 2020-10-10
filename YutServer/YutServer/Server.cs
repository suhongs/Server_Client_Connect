using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using UnityNetwork;

namespace YutServer
{
    class Server
    {
        private NetworkStream m_networkStream;
        private TcpListener m_listener;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bClientOn = false;

        public Thread m_thread;
        public Login m_login;

        public void RUN()
        {
            this.m_listener = new TcpListener(8000);
            this.m_listener.Start();

            if (!this.m_bClientOn)
            {
                Console.WriteLine("클라이언트 접속 대기중");
            }

            TcpClient client = this.m_listener.AcceptTcpClient();

            if (client.Connected)
            {
                this.m_bClientOn = true;
                Console.WriteLine("클라이언트 접속");
                m_networkStream = client.GetStream();
            }

            int nRead = 0;

            while (this.m_bClientOn)
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_networkStream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    this.m_bClientOn = false;
                    this.m_networkStream = null;
                }

                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                switch ((int)packet.Type)
                {
                    case (int)PacketType.접속:
                        {
                            this.m_login = (Login)Packet.Desserialize(this.readBuffer);
                            Console.WriteLine("{0}님이 접속하셨습니다", m_login.userName);
                            break;
                        }
                }
            }
        }
    }
}
