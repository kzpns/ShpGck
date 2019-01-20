/*
 * From MemAreas.cs (TCPGecko .NET) 
 */

using System;

namespace ShpGck
{
    public class GckMemoryRange
    {

        public enum AddressType
        {
            Rw,
            Ro,
            Ex,
            Hardware,
            Unknown
        }

        private AddressType PDesc;
        private Byte PId;
        private UInt32 PLow;
        private UInt32 PHigh;

        public AddressType description { get { return PDesc; } }
        public Byte id { get { return PId; } }
        public UInt32 low { get { return PLow; } }
        public UInt32 high { get { return PHigh; } }

        public GckMemoryRange(AddressType desc, Byte id, UInt32 low, UInt32 high)
        {
            this.PId = id;
            this.PDesc = desc;
            this.PLow = low;
            this.PHigh = high;
        }

        public GckMemoryRange(AddressType desc, UInt32 low, UInt32 high) :
                this(desc, (Byte)(low >> 24), low, high)
        {

        }

        public static readonly GckMemoryRange[] ValidRanges = new GckMemoryRange[] {
             new GckMemoryRange(AddressType.Ex,  0x01000000, 0x01800000),
             new GckMemoryRange(AddressType.Ex,  0x0e300000, 0x10000000),
             new GckMemoryRange(AddressType.Rw,  0x10000000, 0x50000000),
             new GckMemoryRange(AddressType.Ro,  0xe0000000, 0xe4000000),
             new GckMemoryRange(AddressType.Ro,  0xe8000000, 0xea000000),
             new GckMemoryRange(AddressType.Ro,  0xf4000000, 0xf6000000),
             new GckMemoryRange(AddressType.Ro,  0xf6000000, 0xf6800000),
             new GckMemoryRange(AddressType.Ro,  0xf8000000, 0xfb000000),
             new GckMemoryRange(AddressType.Ro,  0xfb000000, 0xfb800000),
             new GckMemoryRange(AddressType.Rw,  0xfffe0000, 0xffffffff)
            };

        public static bool addressDebug = false;

        public static AddressType RangeCheck(UInt32 address)
        {
            int id = RangeCheckId(address);
            if (id == -1)
                return AddressType.Unknown;
            else
                return ValidRanges[id].description;
        }

        public static int RangeCheckId(UInt32 address)
        {
            for (int i = 0; i < ValidRanges.Length; i++)
            {
                GckMemoryRange range = ValidRanges[i];
                if (address >= range.low && address < range.high)
                    return i;
            }
            return -1;
        }

        public static bool ValidAddress(UInt32 address, bool debug)
        {
            if (debug)
                return true;
            return (RangeCheckId(address) >= 0);
        }

        public static bool ValidAddress(UInt32 address)
        {
            return ValidAddress(address, addressDebug);
        }

        public static bool ValidRange(UInt32 low, UInt32 high, bool debug)
        {
            if (debug)
                return true;
            return (RangeCheckId(low) == RangeCheckId(high - 1));
        }

        public static bool ValidRange(UInt32 low, UInt32 high)
        {
            return ValidRange(low, high, addressDebug);
        }
    }
}
