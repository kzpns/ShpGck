namespace ShpGck
{
    public class GeckoMemoryAddress
    {
        private bool IsPhysics;
        private int Address;

        private GeckoMemoryAddress(int address, bool isPhysics)
        {
            IsPhysics = isPhysics;
            Address = address;
        }

        public int GetAddress(GeckoClient client)
        {
            if(!IsPhysics)
            {
                return Address;
            }
            return Address;
        }

        public static GeckoMemoryAddress FromEffective(int effective)
        {
            return new GeckoMemoryAddress(effective, false);
        }

        public static GeckoMemoryAddress FromPhysics(int physics)
        {
            return new GeckoMemoryAddress(physics, true);
        }
    }
}
