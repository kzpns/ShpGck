using System;
using System.Collections.Generic;
using System.Text;

namespace ShpGck
{
    public static class GeckoConverter
    {
        public static readonly bool IsLittleEndian = BitConverter.IsLittleEndian;

        public static byte[] GetBytes(GeckoCommand value)
        {
            return new byte[]
            {
                (byte)value
            };
        }

        public static GeckoCommand ToGeckoCommand(byte[] value, int startIndex)
        {
            return (GeckoCommand)value[startIndex + 0];
        }
    }
}
