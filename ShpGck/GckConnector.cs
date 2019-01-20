using System;
using System.Net.Sockets;
using System.Collections.Generic;

namespace ShpGck
{
    public class GckConnector
    {
        public GckConnector()
        {
            BaseConnector = new TcpClient()
            {
                NoDelay = true,
                ReceiveTimeout = 3000,
                SendTimeout = 3000,
            };
            Buffer = new List<byte>();
            Stream = null;
        }

        public void Close()
        {
            if(Connected)
            {
                Disconnect();
            }
            BaseConnector.Client.Close();
            BaseConnector.Close();
        }

        public void Connect(string host, int port)
        {
            if(Connected)
            {
                Disconnect();
            }

            BaseConnector.Connect(host, port);
            Stream = BaseConnector.GetStream();
        }

        public void Disconnect()
        {
            if(!Connected)
            {
                return;
            }
            BaseConnector.Client.Disconnect(true);
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

        public void WriteCmd(GckCommands cmd)
        {
            Buffer.Add((byte)cmd);
        }

        public void WriteBytes(byte[] buf, int length = -1)
        {
            if(length < 0)
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

        public void WriteUInt16(ushort value)
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

        public void WriteSingle(float val)
        {
            byte[] buf = BitConverter.GetBytes(val);
            if(BitConverter.IsLittleEndian)
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

        public byte ReadUInt8()
        {
            byte[] buf = ReadBytes(sizeof(byte));
            return buf[0];
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

        public uint ReadUInt32()
        {
            byte[] buf = ReadBytes(sizeof(uint));
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(buf);
            }
            return BitConverter.ToUInt32(buf, 0);
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

        public byte[] ReadBytes(int length)
        {
            byte[] buf = new byte[length];
            Stream.Read(buf, 0, length);
            return buf;
        }
		
		public void ReadBytes(byte[] buf, int length = -1)
        {
            if(length < 0)
            {
                length = buf.Length;
            }
            Stream.Read(buf, 0, length);
        }

        public bool Connected
        {
            get
            {
                return BaseConnector.Connected;
            }
        }

        protected TcpClient BaseConnector
        {
            get;
            set;
        }

        protected NetworkStream Stream
        {
            get;
            set;
        }

        protected List<byte> Buffer
        {
            get;
            set;
        }
    }
}
