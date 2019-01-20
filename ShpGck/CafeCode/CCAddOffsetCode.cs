namespace ShpGck.CafeCode
{
    public class CCAddOffsetCode : CafeCode
    {
        public CCAddOffsetCode(uint offset)
        {
            Offset = offset;
        }

        public byte GetCafeCodeID()
        {
            return 0x31;
        }

        public uint[] ToRaw()
        {
            return new uint[]
                {(uint)GetCafeCodeID() << 24, Offset};
        }

        public uint Offset
        {
            get;
            private set;
        }
    }
}
