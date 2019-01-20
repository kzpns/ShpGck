namespace ShpGck.CafeCode
{
    public class CCConditionalEqualCode : CafeCode
    {
        public CCConditionalEqualCode(uint addr, byte val, bool isPtr = false)
        {
            ValueSize = ValueSize.UInt8;
            Address = addr;
            Value = val;
            IsPointer = isPtr;
        }

        public CCConditionalEqualCode(uint addr, ushort val, bool isPtr = false)
        {
            ValueSize = ValueSize.UInt16;
            Address = addr;
            Value = val;
            IsPointer = isPtr;
        }

        public CCConditionalEqualCode(uint addr, uint val, bool isPtr = false)
        {
            ValueSize = ValueSize.UInt32;
            Address = addr;
            Value = val;
            IsPointer = isPtr;
        }

        public CCConditionalEqualCode(uint addr, uint val, ValueSize valSize, bool isPtr = false)
        {
            ValueSize = valSize;
            Address = addr;
            Value = val;
            IsPointer = isPtr;
        }

        public byte GetCafeCodeID()
        {
            return 0x03;
        }

        public uint[] ToRaw()
        {
            int size = 4;
            if (IsPointer)
            {
                size = 2;
            }
            uint[] ret = new uint[size];

            ret[0] = (uint)GetCafeCodeID() << 24;
            ret[0] |= (uint)(((byte)ValueSize & 0xF) << 16);
            if (IsPointer)
            {
                ret[0] |= 0x00100000;
                ret[0] |= Address & 0xFFFF;
                ret[1] = Value;
                return ret;
            }

            ret[1] = Address;
            ret[2] = Value;
            ret[3] = 0;
            return ret;
        }

        public uint Address
        {
            get;
            private set;
        }

        public uint Value
        {
            get;
            private set;
        }

        public bool IsPointer
        {
            get;
            private set;
        }

        public ValueSize ValueSize
        {
            get;
            private set;
        }
    }
}
