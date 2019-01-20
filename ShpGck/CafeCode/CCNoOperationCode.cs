namespace ShpGck.CafeCode
{
    public class CCNoOperationCode : CafeCode
    {
        public CCNoOperationCode()
        {

        }

        public byte GetCafeCodeID()
        {
            return 0xD1;
        }

        public uint[] ToRaw()
        {
            return new uint[]
                {(uint)GetCafeCodeID() << 24, 0xDEADC0DE};
        }
    }
}
