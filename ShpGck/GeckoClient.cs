using System;
using System.Collections.Generic;
using System.Text;

namespace ShpGck
{
    public class GeckoClient
    {
        public GeckoClient(IGeckoConnector connector)
        {
            Connector = connector;
            Stream = connector.GetStream();
            Memory = new GeckoMemoryIO(this);
            CodeHandler = new CafeCodeHandler(this);

            DataBufferSize = GetBufferSize();
        }

        private int GetBufferSize()
        {
            Stream.WriteCommand(GeckoCommand.GetDataBufferSize);
            return Stream.ReadInt32();
        }

        public int DataBufferSize
        {
            get;
            private set;
        }

        public IGeckoConnector Connector
        {
            get;
            private set;
        }


        public GeckoStream Stream
        {
            get;
            private set;
        }

        public GeckoMemoryIO Memory
        {
            get;
            private set;
        }

        public CafeCodeHandler CodeHandler
        {
            get;
            private set;
        }
    }
}
