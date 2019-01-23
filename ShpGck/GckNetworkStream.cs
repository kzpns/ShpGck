using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ShpGck
{
    public class GckNetworkStream
    {
        public GckNetworkStream(GckConnector connector)
        {
            Buffer = new List<byte>();
            Stream = connector.BaseClient.GetStream();
        }

        public void BufferClear()
        {
            Buffer.Clear();
        }

        public void Flush()
        {
            byte[] buf = Buffer.ToArray();
            Stream.Write(buf, 0, buf.Length);
            BufferClear();
        }

        public void WriteCommand(GckCommands cmd)
        {
            Buffer.Add((byte)cmd);
        }

        public void WriteBytes(byte[] buf)
        {
            WriteBytes(buf, buf.Length);
        }        public void WriteBytes(byte[] buf, int length)
        {
            if (length < 0)
            {
                length = buf.Length;
            }
            byte[] newBuf = new byte[length];
            Array.Copy(buf, newBuf, length);
            Buffer.AddRange(newBuf);
        }

        public void WriteUInt8(byte value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteInt8(sbyte value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteUInt16(ushort value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteInt16(short value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteUInt32(uint value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteInt32(int value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteUInt64(ulong value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteInt64(long value)
        {
            byte[] buf = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteSingle(float val)
        {
            byte[] buf = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public void WriteDouble(double val)
        {
            byte[] buf = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            Buffer.AddRange(buf);
        }

        public byte[] ReadBytes(int length)
        {
            byte[] buf = new byte[length];
            Stream.Read(buf, 0, length);
            return buf;
        }

        public byte ReadUInt8()
        {
            byte[] buf = ReadBytes(sizeof(byte));
            return buf[0];
        }

        public sbyte ReadInt8()
        {
            byte[] buf = ReadBytes(sizeof(sbyte));
            return Convert.ToSByte(buf[0]);
        }

        public ushort ReadUInt16()
        {
            byte[] buf = ReadBytes(sizeof(ushort));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToUInt16(buf, 0);
        }

        public short ReadInt16()
        {
            byte[] buf = ReadBytes(sizeof(short));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToInt16(buf, 0);
        }

        public uint ReadUInt32()
        {
            byte[] buf = ReadBytes(sizeof(uint));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToUInt32(buf, 0);
        }

        public int ReadInt32()
        {
            byte[] buf = ReadBytes(sizeof(int));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToInt32(buf, 0);
        }

        public ulong ReadUInt64()
        {
            byte[] buf = ReadBytes(sizeof(ulong));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToUInt64(buf, 0);
        }

        public long ReadInt64()
        {
            byte[] buf = ReadBytes(sizeof(long));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToInt64(buf, 0);
        }

        public float ReadSingle()
        {
            byte[] buf = ReadBytes(sizeof(float));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToSingle(buf, 0);
        }

        public double ReadDouble()
        {
            byte[] buf = ReadBytes(sizeof(double));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToDouble(buf, 0);
        }

        protected NetworkStream Stream
        {
            get;
        }

        protected List<byte> Buffer
        {
            get;
            set;
        }
    }
}
