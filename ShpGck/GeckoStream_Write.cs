using System;

namespace ShpGck
{
    partial class GeckoStream
    {
        public void WriteInt8(sbyte value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(sbyte));
        }

        public void WriteUInt8(byte value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(byte));
        }

        public void WriteInt16(short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(short));
        }

        public void WriteUInt16(ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(ushort));
        }

        public void WriteInt32(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(int));
        }

        public void WriteUInt32(uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(uint));
        }

        public void WriteInt64(long value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(long));
        }

        public void WriteUInt64(ulong value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(ulong));
        }

        public void WriteBytes(byte[] value)
        {
            Write(value, 0, value.Length);
        }

        public void WriteCommand(GeckoCommand value)
        {
            byte[] bytes = GeckoConverter.GetBytes(value);
            EndianizeBytes(bytes);
            Write(bytes, 0, sizeof(GeckoCommand));
        }
    }
}
