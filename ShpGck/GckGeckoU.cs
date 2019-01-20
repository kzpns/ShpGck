using System;
using System.Collections.Generic;
using ShpGck.CafeCode;

namespace ShpGck
{
    public class GckGeckoU
    {
        public const int GECKO_PORT = 7331;
		
		public const uint CODE_HANDLER_CODE_START_ADDRESS = 0x01133000;
		public const uint CODE_HANDLER_CODE_END_ADDRESS = 0x01134300;
		public const uint CODE_HANDLER_STATUS_ADDRESS = 0x10014CFC;

        public const byte BYTES_ONLY_ZEROS = 0xB0;
        public const byte BYTES_NON_ZEROS = 0xBD;

        public GckGeckoU()
        {
            Connector = new GckConnector();
        }

        public void Connect(string host)
        {
            Connector.Connect(host, GECKO_PORT);
        }

        public void Disconnect()
        {
            Connector.Disconnect();
        }

        public byte ReadUInt8(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.ReadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(byte));
            Connector.Flush();

            if (Connector.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Connector.ReadUInt8();
        }

        public sbyte ReadInt8(uint addr)
        {
            return Convert.ToSByte(ReadUInt8(addr));
        }

        public ushort ReadUInt16(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.ReadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(ushort));
            Connector.Flush();

            if (Connector.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Connector.ReadUInt16();
        }

        public short ReadInt16(uint addr)
        {
            return Convert.ToInt16(ReadUInt16(addr));
        }

        public uint ReadUInt32(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.ReadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(uint));
            Connector.Flush();

            if (Connector.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Connector.ReadUInt32();
        }

        public int ReadInt32(uint addr)
        {
            return Convert.ToInt32(ReadInt32(addr));
        }

        public float ReadSingle(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.ReadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(float));
            Connector.Flush();

            if (Connector.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Connector.ReadSingle();
        }

        public double ReadDouble(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.ReadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(double));
            Connector.Flush();

            if (Connector.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Connector.ReadDouble();
        }

        public byte[] ReadBytes(uint addr, int length)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.ReadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + (uint)length);
            Connector.Flush();

            if (Connector.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return new byte[length];
            }
            return Connector.ReadBytes(length);
        }

        public void WriteUInt8(uint addr, byte val)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.UploadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(byte));
            Connector.WriteUInt8(val);
            Connector.Flush();
        }

        public void WriteInt8(uint addr, sbyte val)
        {
            WriteUInt8(addr, Convert.ToByte(val));
        }

        public void WriteUInt16(uint addr, ushort val)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.UploadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(ushort));
            Connector.WriteUInt16(val);
            Connector.Flush();
        }

        public void WriteInt16(uint addr, short val)
        {
            WriteUInt16(addr, Convert.ToUInt16(val));
        }

        public void WriteUInt32(uint addr, uint val)
		{
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.UploadMemory);
			Connector.WriteUInt32(addr);
			Connector.WriteUInt32(addr + sizeof(uint));
			Connector.WriteUInt32(val);
            Connector.Flush();
        }

        public void WriteInt32(uint addr, uint val)
        {
            WriteUInt32(addr, Convert.ToUInt32(val));
        }

        public void WriteSingle(uint addr, float val)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.UploadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(float));
            Connector.WriteSingle(val);
            Connector.Flush();
        }

        public void WriteDouble(uint addr, double val)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Connector.WriteCmd(GckCommands.UploadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + sizeof(double));
            Connector.WriteDouble(val);
            Connector.Flush();
        }

        public void WriteBytes(uint addr, byte[] buf, int length = -1)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            if (length < 0)
            {
                length = buf.Length;
            }
            Connector.WriteCmd(GckCommands.UploadMemory);
            Connector.WriteUInt32(addr);
            Connector.WriteUInt32(addr + (uint)length);
            Connector.WriteBytes(buf, length);
            Connector.Flush();
        }

        public uint GetCodeHandlerAddress()
		{
            Connector.WriteCmd(GckCommands.GetCodeHandlerAddress);
            Connector.Flush();
            return Connector.ReadUInt32();
		}

        public void SendCodes(params CafeCode.CafeCode[] codes)
        {
            ClearCodes();
            int length = (int)(CODE_HANDLER_CODE_END_ADDRESS - CODE_HANDLER_CODE_START_ADDRESS);
            List<byte> buf = new List<byte>();
            foreach(CafeCode.CafeCode code in codes)
            {
                if(code == null)
                {
                    continue;
                }
                foreach(uint raw in code.ToRaw())
                {
                    byte[] rawbytes = BitConverter.GetBytes(raw);
                    if(BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(rawbytes);
                    }
                    buf.AddRange(rawbytes);
                }
            }
            if (length < buf.Count)
            {
                throw new GckException("code lines too long.");
            }
            WriteBytes(CODE_HANDLER_CODE_START_ADDRESS, buf.ToArray());
        }

        public void ClearCodes()
        {
            DisableCodeHandler();
            int length = (int)(CODE_HANDLER_CODE_END_ADDRESS - CODE_HANDLER_CODE_START_ADDRESS);
            WriteBytes(CODE_HANDLER_CODE_START_ADDRESS, new byte[length]);
        }
		
		public void DisableCodeHandler()
		{
            if (!Connected)
            {
                return;
            }
            WriteUInt32(CODE_HANDLER_STATUS_ADDRESS, 0);
		}
		
		public void EnableCodeHandler()
		{
            if (!Connected)
            {
                return;
            }
            WriteUInt32(CODE_HANDLER_STATUS_ADDRESS, 1);
		}
		
		public bool CodeHandlerEnabled()
		{
            if (!Connected)
            {
                throw new GckException("not connected");
            }
            return ReadInt32(CODE_HANDLER_STATUS_ADDRESS) != 0;
		}

        public bool Connected
        {
            get
            {
                return Connector.Connected;
            }
        }

        protected GckConnector Connector
        {
            get;
            set;
        }
    }
}
