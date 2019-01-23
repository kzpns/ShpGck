namespace ShpGck.CafeCode
{
    public class CCConditionalEqual : CafeCode
    {
        public CCConditionalEqual(uint addr, uint val, ValueSize valSize) : this(addr, val, valSize, false)
        {

        }

        public CCConditionalEqual(uint addr, uint val, ValueSize valSize, bool isPtr)
        {
            ValueSize = valSize;
            Address = addr;
            Value = val;
            IsPointer = isPtr;
        }

        public override byte GetCafeCodeID()
        {
            return 0x03;
        }

        public override uint[] ToRaw()
        {
            uint[] ret = new uint[4];

            ret[0] = (uint)GetCafeCodeID() << 24;
            ret[0] |= (uint)(((byte)ValueSize & 0xF) << 16);
            if (IsPointer)
            {
                ret[0] |= 0x00100000;
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
