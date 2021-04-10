using System;
using System.IO;

namespace ShpGck
{
    public interface IGeckoConnector
    {
        void Disconnect();

        GeckoStream GetStream();

        bool IsConnected
        {
            get;
        }
    }
}
