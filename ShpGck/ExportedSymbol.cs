namespace ShpGck
{
    public class ExportedSymbol
    {
        public ExportedSymbol(uint addr) : this(addr, string.Empty, string.Empty)
        {

        }

        public ExportedSymbol(uint addr, string rplName, string symbolName)
        {
            Address = addr;
            RPLName = rplName;
            SymbolName = symbolName;
        }

        public long Invoke(GckGeckoU gecko, params int[] args)
        {
            if(Address == 0)
            {
                throw new GckException("Invalid function address.");
            }
            return gecko.RemoteProcedureCall(Address, args);
        }

        public uint Address
        {
            get;
            private set;
        }

        public string RPLName
        {
            get;
            private set;
        }

        public string SymbolName
        {
            get;
            private set;
        }
    }
}
