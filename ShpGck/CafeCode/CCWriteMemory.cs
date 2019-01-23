namespace ShpGck.CafeCode
{
    public class CCWriteMemory : CafeCode
    {
        public CCWriteMemory(uint addr, uint val, ValueSize valSize) : this(addr, val, valSize, false)
        {

        }

        public CCWriteMemory(uint addr, uint val, ValueSize valSize, bool isPtr)
        {
            ValueSize = valSize;
            Address = addr;
            Value = val;
            IsPointer = isPtr;
        }

        public override byte GetCafeCodeID()
        {
            return 0x00;
        }

        public override uint[] ToRaw()
        {
            int size = 4;
            if(IsPointer)
            {
                size = 2;
            }
            uint[] ret = new uint[size];

            ret[0] = (uint)GetCafeCodeID() << 24 |
                (uint)(((byte)ValueSize & 0xF) << 16);
            if(IsPointer)
            {
                ret[0] |= 0x00100000 | 
                    (Address & 0xFFFF);
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
