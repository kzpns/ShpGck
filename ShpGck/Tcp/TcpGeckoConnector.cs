using System;
using System.Net;
using System.Net.Sockets;

namespace ShpGck.Tcp
{
    public class TcpGeckoConnector : IGeckoConnector
    {
        static readonly int DefaultTcpPort = 7331;

        private TcpClient BaseClient = new TcpClient();

        private GeckoStream BaseStream;

        public TcpGeckoConnector()
        {

        }

        public void Connect(string server)
        {
            Connect(IPAddress.Parse(server), DefaultTcpPort);
        }

        public void Connect(IPAddress server)
        {
            Connect(server, DefaultTcpPort);
        }

        public void Connect(string server, int port)
        {
            Connect(IPAddress.Parse(server), port);
        }

        public void Connect(IPAddress server, int port)
        {
            BaseClient.Connect(server, port);
        }

        public void Disconnect()
        {
            if (BaseStream != null)
            {
                BaseStream.Close();
            }
            BaseClient.Close();
        }

        public GeckoStream GetStream()
        {
            if (BaseStream == null)
            {
                BaseStream = new TcpGeckoStream(BaseClient.GetStream());
            }
            return BaseStream;
        }

        public bool IsConnected => BaseClient.Connected;
    }
}
