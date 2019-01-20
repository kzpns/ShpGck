namespace ShpGck.CafeCode
{
    public class CCTerminatorCode : CafeCode
    {
        public CCTerminatorCode()
        {

        }

        public byte GetCafeCodeID()
        {
            return 0xD0;
        }

        public uint[] ToRaw()
        {
            return new uint[]
                { (uint)GetCafeCodeID() << 24, 0xDEADCAFE};
        }
    }
}
