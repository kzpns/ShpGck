namespace ShpGck.CafeCode
{
    public class CCFollowPointerCode : CafeCode
    {
        public const uint DefaultRangeMin = 0x10000000;
        public const uint DefaultRangeMax = 0x50000000;

        public CCFollowPointerCode(uint addr, uint rangeMin = DefaultRangeMin, uint rangeMax = DefaultRangeMax, bool isPtr = false)
        {
            Address = addr;
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            IsPointer = isPtr;
        }

        public CCFollowPointerCode(bool isPtr = true, uint rangeMin = DefaultRangeMin, uint rangeMax = DefaultRangeMax)
        {
            Address = 0;
            RangeMin = rangeMin;
            RangeMax = rangeMax;
            IsPointer = isPtr;
        }

        public byte GetCafeCodeID()
        {
            return 0x30;
        }

        public uint[] ToRaw()
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
