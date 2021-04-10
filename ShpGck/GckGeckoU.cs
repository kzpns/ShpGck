using System;
using System.Text;
using System.Collections.Generic;
using ShpGck.CafeCode;

namespace ShpGck
{
    public class GckGeckoU
    {
        public const int GECKO_PORT = 7331;
        public const int MAX_RPC_ARGS = 8;

		public const uint CODE_HANDLER_CODE_START_ADDRESS = 0x01133000;
		public const uint CODE_HANDLER_CODE_END_ADDRESS = 0x01134300;
		public const uint CODE_HANDLER_STATUS_ADDRESS = 0x10014CFC;

        public const byte BYTES_ONLY_ZEROS = 0xB0;
        public const byte BYTES_NON_ZEROS = 0xBD;

        public GckGeckoU()
        {
            Connector = new GckConnector();
            Stream = new GckNetworkStream(Connector);
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
            Stream.WriteCommand(GeckoCommand.ReadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(byte));
            Stream.Flush();

            if (Stream.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Stream.ReadUInt8();
        }

        public sbyte ReadInt8(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.ReadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(sbyte));
            Stream.Flush();

            if (Stream.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Stream.ReadInt8();
        }

        public ushort ReadUInt16(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.ReadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(ushort));
            Stream.Flush();

            if (Stream.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Stream.ReadUInt16();
        }

        public short ReadInt16(uint addr)
        {
            return Convert.ToInt16(ReadUInt16(addr));
        }

        public uint ReadUInt32(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.ReadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(uint));
            Stream.Flush();

            if (Stream.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Stream.ReadUInt32();
        }

        public int ReadInt32(uint addr)
        {
            return Convert.ToInt32(ReadInt32(addr));
        }

        public float ReadSingle(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.ReadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(float));
            Stream.Flush();

            if (Stream.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Stream.ReadSingle();
        }

        public double ReadDouble(uint addr)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.ReadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(double));
            Stream.Flush();

            if (Stream.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return 0;
            }
            return Stream.ReadDouble();
        }

        public byte[] ReadBytes(uint addr, int length)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.ReadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + (uint)length);
            Stream.Flush();

            if (Stream.ReadUInt8() == BYTES_ONLY_ZEROS)
            {
                return new byte[length];
            }
            return Stream.ReadBytes(length);
        }

        public void WriteUInt8(uint addr, byte val)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.UploadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(byte));
            Stream.WriteUInt8(val);
            Stream.Flush();
        }

        public void WriteInt8(uint addr, sbyte val)
        {
            WriteUInt8(addr, Convert.ToByte(val));
        }

        public void WriteUInt16(uint addr, ushort val)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.UploadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(ushort));
            Stream.WriteUInt16(val);
            Stream.Flush();
        }

        public void WriteInt16(uint addr, short val)
        {
            WriteUInt16(addr, Convert.ToUInt16(val));
        }

        public void WriteUInt32(uint addr, uint val)
		{
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.UploadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(uint));
            Stream.WriteUInt32(val);
            Stream.Flush();
        }

        public void WriteInt32(uint addr, int val)
        {
            WriteUInt32(addr, Convert.ToUInt32(val));
        }

        public void WriteSingle(uint addr, float val)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.UploadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(float));
            Stream.WriteSingle(val);
            Stream.Flush();
        }

        public void WriteDouble(uint addr, double val)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.UploadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + sizeof(double));
            Stream.WriteDouble(val);
            Stream.Flush();
        }

        public void WriteBytes(uint addr, byte[] buf)
        {
            WriteBytes(addr, buf, buf.Length);
        }

        public void WriteBytes(uint addr, byte[] buf, int length)
        {
            if (!GckMemoryRange.ValidAddress(addr))
                throw new GckException("Invalid memory range.");
            Stream.WriteCommand(GeckoCommand.UploadMemory);
            Stream.WriteUInt32(addr);
            Stream.WriteUInt32(addr + (uint)length);
            Stream.WriteBytes(buf, length);
            Stream.Flush();
        }

        public uint GetSymbol(string rplName, string symbolName)
        {
            byte[] rplNameBytes = Encoding.ASCII.GetBytes(rplName);
            byte[] symbolNameBytes = Encoding.ASCII.GetBytes(symbolName);
            Stream.WriteCommand(GeckoCommand.GetSymbol);
            Stream.WriteInt32(rplNameBytes.Length + symbolNameBytes.Length);
            Stream.WriteUInt8((byte)rplNameBytes.Length);
            Stream.WriteBytes(rplNameBytes);
            Stream.WriteUInt8((byte)symbolNameBytes.Length);
            Stream.WriteBytes(symbolNameBytes);
            Stream.Flush();
            return Stream.ReadUInt32();
        }

        public int GetVersionHash()
        {
            Stream.WriteCommand(GeckoCommand.GetVersionHash);
            Stream.Flush();
            return Stream.ReadInt32();
        }

        public long RemoteProcedureCall(uint addr, params int[] args)
        {
            if(args.Length > MAX_RPC_ARGS)
            {
                throw new GckException("Too many arguments.");
            }
            uint[] _args = new uint[MAX_RPC_ARGS];
            args.CopyTo(_args, 0);
            Stream.WriteCommand(GeckoCommand.RemoteProcudureCode);
            Stream.WriteUInt32(addr);
            foreach(int arg in _args)
            {
                Stream.WriteInt32(arg);
            }
            Stream.Flush();
            return Stream.ReadInt64();
        }

        public uint GetCodeHandlerAddress()
		{
            Stream.WriteCommand(GeckoCommand.GetCodeHandlerAddress);
            Stream.Flush();
            return Stream.ReadUInt32();
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
                throw new GckException("too long code lines.");
            }
            WriteBytes(CODE_HANDLER_CODE_START_ADDRESS, buf.ToArray());
        }

        public void ClearCodes()
        {
            EnableCodeHandler(false);
            int length = (int)(CODE_HANDLER_CODE_END_ADDRESS - CODE_HANDLER_CODE_START_ADDRESS);
            WriteBytes(CODE_HANDLER_CODE_START_ADDRESS, new byte[length]);
        }
		
		public void EnableCodeHandler(bool flag)
		{
            if (!Connected)
            {
                return;
            }
            WriteInt32(CODE_HANDLER_STATUS_ADDRESS, Convert.ToInt32(flag));
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

        public GckNetworkStream Stream
        {
            get;
            protected set;
        }
    }
}
