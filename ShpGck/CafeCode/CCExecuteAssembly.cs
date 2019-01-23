using System;

namespace ShpGck.CafeCode
{
    public class CCExecuteAssembly : CafeCode
    {
        public CCExecuteAssembly(params uint[] raw)
        {
            if((raw.Length % 2) == 1)
            {
                PPCByteCodes = new uint[raw.Length + 1];
                Array.Copy(raw, PPCByteCodes, raw.Length);
                PPCByteCodes[PPCByteCodes.Length - 1] = 0x60000000; //nop
            }
            else
            {
                PPCByteCodes = new uint[raw.Length];
                Array.Copy(raw, PPCByteCodes, raw.Length);
            }
        }

        public override byte GetCafeCodeID()
        {
            return 0xC0;
        }

        public override uint[] ToRaw()
        {
            uint[] ret = new uint[PPCByteCodes.Length + 2];
            ret[0] = (uint)(GetCafeCodeID() << 24);
            ret[0] |= (uint)(PPCByteCodes.Length / 2) & 0xFFFF;
            ret[1] = 0x60000000; //nop
            Array.Copy(PPCByteCodes, 0, ret, 2, PPCByteCodes.Length);
            return ret;
        }

        public uint[] PPCByteCodes
        {
            get;
            private set;
        }
    }
}
