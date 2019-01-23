namespace ShpGck.CafeCode
{
    public class CCFollowPointer : CafeCode
    {
        public static readonly uint DefaultRangeMin = 0x10000000;
        public static readonly uint DefaultRangeMax = 0x50000000;

        public CCFollowPointer(uint addr) : this(addr, false, DefaultRangeMin, DefaultRangeMax)
        {

        }

        public CCFollowPointer(uint addr, bool isPtr) : this(addr, isPtr, DefaultRangeMin, DefaultRangeMax)
        {

        }

        public CCFollowPointer(uint addr, bool isPtr, uint rangeMin, uint rangeMax)
        {
            Address = addr;
            IsPointer = isPtr;
            RangeMin = rangeMin;
            RangeMax = rangeMax;
        }

        public override byte GetCafeCodeID()
        {
            return 0x30;
        }

        public override uint[] ToRaw()
        {
            uint[] ret = new uint[4];
            ret[0] = (uint)GetCafeCodeID() << 24;
            if(IsPointer)
            {
                ret[0] |= 0x00100000;
            }
            ret[1] = Address;
            ret[2] = RangeMin;
            ret[3] = RangeMax;
            return ret;
        }

        public uint Address
        {
            get;
            private set;
        }

        public uint RangeMin
        {
            get;
            private set;
        }

        public uint RangeMax
        {
            get;
            private set;
        }

        public bool IsPointer
        {
            get;
            private set;
        }
    }
}
