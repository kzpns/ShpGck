using System;
using System.IO;

namespace ShpGck
{
    public abstract partial class GeckoStream : Stream
    {
        public sbyte ReadInt8()
        {
            return (sbyte)ReadConvertBytes(sizeof(sbyte))[0];
        }

        public byte ReadUInt8()
        {
            return ReadConvertBytes(sizeof(byte))[0];
        }

        public short ReadInt16()
        {
            return BitConverter.ToInt16(ReadConvertBytes(sizeof(short)), 0);
        }

        public ushort ReadUInt16()
        {
            return BitConverter.ToUInt16(ReadConvertBytes(sizeof(ushort)), 0);
        }

        public int ReadInt32()
        {
            return BitConverter.ToInt32(ReadConvertBytes(sizeof(int)), 0);
        }

        public uint ReadUInt32()
        {
            return BitConverter.ToUInt32(ReadConvertBytes(sizeof(uint)), 0);
        }

        public long ReadInt64()
        {
            return BitConverter.ToInt64(ReadConvertBytes(sizeof(long)), 0);
        }

        public ulong ReadUInt64()
        {
            return BitConverter.ToUInt64(ReadConvertBytes(sizeof(ulong)), 0);
        }

        public byte[] ReadBytes(int bytesRead)
        {
            byte[] bytes = new byte[bytesRead];
            Read(bytes, 0, bytesRead);
            return bytes;
        }

        public GeckoCommand ReadCommand()
        {
            return GeckoConverter.ToGeckoCommand(ReadConvertBytes(sizeof(GeckoCommand)), 0);
        }

        private byte[] ReadConvertBytes(int bytesRead)
        {
            byte[] buf = new byte[bytesRead];
            Read(buf, 0, bytesRead);

            if(BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }

            return buf;
        }

        private void EndianizeBytes(byte[] bytes)
        {
            if(BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
        }
    }
}
