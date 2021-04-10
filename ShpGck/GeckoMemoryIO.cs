using System;
using System.Collections.Generic;
using System.Text;

namespace ShpGck
{
    public class GeckoMemoryIO
    {
        private GeckoClient Client;

        public GeckoMemoryIO(GeckoClient client)
        {
            Client = client;
        }

        public void WriteInt8(GeckoMemoryAddress address, sbyte value)
        {
            int rawAddress = address.GetAddress(Client);
            Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
            Client.Stream.WriteInt32(rawAddress);
            Client.Stream.WriteInt32(unchecked(rawAddress + sizeof(sbyte)));
            Client.Stream.WriteInt8(value);
            Client.Stream.Flush();
        }

        public void WriteUInt8(GeckoMemoryAddress address, byte value)
        {
            int rawAddress = address.GetAddress(Client);
            Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
            Client.Stream.WriteInt32(rawAddress);
            Client.Stream.WriteInt32(unchecked(rawAddress + sizeof(byte)));
            Client.Stream.WriteUInt8(value);
            Client.Stream.Flush();
        }

        public void WriteInt16(GeckoMemoryAddress address, short value)
        {
            int rawAddress = address.GetAddress(Client);
            Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
            Client.Stream.WriteInt32(rawAddress);
            Client.Stream.WriteInt32(unchecked(rawAddress + sizeof(short)));
            Client.Stream.WriteInt16(value);
            Client.Stream.Flush();
        }

        public void WriteUInt16(GeckoMemoryAddress address, ushort value)
        {
            int rawAddress = address.GetAddress(Client);
            Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
            Client.Stream.WriteInt32(rawAddress);
            Client.Stream.WriteInt32(unchecked(rawAddress + sizeof(ushort)));
            Client.Stream.WriteUInt16(value);
            Client.Stream.Flush();
        }

        public void WriteInt32(GeckoMemoryAddress address, int value)
        {
            int rawAddress = address.GetAddress(Client);
            Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
            Client.Stream.WriteInt32(rawAddress);
            Client.Stream.WriteInt32(unchecked(rawAddress + sizeof(int)));
            Client.Stream.WriteInt32(value);
            Client.Stream.Flush();
        }

        public void WriteUInt32(GeckoMemoryAddress address, uint value)
        {
            int rawAddress = address.GetAddress(Client);
            Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
            Client.Stream.WriteInt32(rawAddress);
            Client.Stream.WriteInt32(unchecked(rawAddress + sizeof(uint)));
            Client.Stream.WriteUInt32(value);
            Client.Stream.Flush();
        }

        public void WriteInt64(GeckoMemoryAddress address, long value)
        {
            int rawAddress = address.GetAddress(Client);
            Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
            Client.Stream.WriteInt32(rawAddress);
            Client.Stream.WriteInt32(unchecked(rawAddress + sizeof(long)));
            Client.Stream.WriteInt64(value);
            Client.Stream.Flush();
        }

        public void WriteUInt64(GeckoMemoryAddress address, ulong value)
        {
            int rawAddress = address.GetAddress(Client);
            Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
            Client.Stream.WriteInt32(rawAddress);
            Client.Stream.WriteInt32(unchecked(rawAddress + sizeof(ulong)));
            Client.Stream.WriteUInt64(value);
            Client.Stream.Flush();
        }

        public void WriteBytes(GeckoMemoryAddress address, byte[] value)
        {
            int rawAddress = address.GetAddress(Client);
            int remainBytes = value.Length;
            int sendBytes = Math.Min(remainBytes, Client.DataBufferSize - sizeof(GeckoCommand) - sizeof(int) * 2);
            int valueOffset = 0;

            while (remainBytes > 0)
            {
                Client.Stream.WriteCommand(GeckoCommand.UploadMemory);
                Client.Stream.WriteInt32(rawAddress);
                Client.Stream.WriteInt32(unchecked(rawAddress + sendBytes));
                Client.Stream.Write(value, valueOffset, sendBytes);
                Client.Stream.Flush();

                remainBytes -= sendBytes;
                valueOffset += sendBytes;
                rawAddress += sendBytes;
            }
        }
    }
}
