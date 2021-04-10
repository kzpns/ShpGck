using System;
using System.Collections.Generic;

namespace ShpGck.CafeCode
{
    public abstract class CafeCode
    {
        public abstract byte GetCafeCodeID();

        public abstract uint[] ToRaw();

        public byte[] ToBytes()
        {
            List<byte> codeBytes = new List<byte>();
            foreach (uint line in ToRaw())
            {
                byte[] bytes = BitConverter.GetBytes(line);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(bytes);
                }
                codeBytes.AddRange(bytes);
            }
            return codeBytes.ToArray();
        }
    }
}
