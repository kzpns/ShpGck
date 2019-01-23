namespace ShpGck.CafeCode
{
    public class CCAddOffset : CafeCode
    {
        public CCAddOffset(uint offset)
        {
            Offset = offset;
        }

        public override byte GetCafeCodeID()
        {
            return 0x31;
        }

        public override uint[] ToRaw()
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
