namespace ShpGck.CafeCode
{
    public class CCNoOperation : CafeCode
    {
        public CCNoOperation()
        {

        }

        public override byte GetCafeCodeID()
        {
            return 0xD1;
        }

        public override uint[] ToRaw()
        {
            return new uint[]
                {(uint)GetCafeCodeID() << 24, 0xDEADC0DE};
        }
    }
}
