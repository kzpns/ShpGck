using System;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ShpGck
{
    public class GckConnector
    {
        public GckConnector()
        {
            BaseClient = new TcpClient()
            {
                NoDelay = true,
                ReceiveTimeout = 3000,
                SendTimeout = 3000,
            };
        }

        public void Close()
        {
            if(Connected)
            {
                Disconnect();
            }
            BaseClient.Client.Close();
            BaseClient.Close();
        }

        public void Connect(string host, int port)
        {
            if (Connected)
            {
                Disconnect();
            }
            BaseClient.Connect(host, port);
        }

        public void Disconnect()
        {
            if(!Connected)
            {
                return;
            }
            BaseClient.Client.Disconnect(true);
        }

        public bool Connected
        {
            get
            {
                return BaseClient.Connected;
            }
        }

        public TcpClient BaseClient
        {
            get;
        }
    }
}
