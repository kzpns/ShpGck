using System;
using System.Collections.Generic;
using System.Text;

namespace ShpGck
{
    public class CafeCodeHandler
    {
        public static readonly GeckoMemoryAddress CafeCodeStartAddress = 
            GeckoMemoryAddress.FromEffective(0x01133000);

        public static readonly GeckoMemoryAddress CafeCodeEndAddress = 
            GeckoMemoryAddress.FromEffective(0x01134300);

        public static readonly GeckoMemoryAddress StatusAddress =
            GeckoMemoryAddress.FromEffective(0x10014CFC);

        private GeckoClient Client;

        public CafeCodeHandler(GeckoClient client)
        {
            Client = client;
        }

        public void SetEnabled(bool status)
        {
            Client.Memory.WriteInt32(StatusAddress, Convert.ToInt32(status));
        }

        public void ClearCode()
        {
            SetEnabled(false);
        }
    }
}
