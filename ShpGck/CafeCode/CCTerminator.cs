namespace ShpGck.CafeCode
{
    public class CCTerminator : CafeCode
    {
        public CCTerminator()
        {

        }

        public override byte GetCafeCodeID()
        {
            return 0xD0;
        }

        public override uint[] ToRaw()
        {
            return new uint[]
                { (uint)GetCafeCodeID() << 24, 0xDEADCAFE};
        }
    }
}
