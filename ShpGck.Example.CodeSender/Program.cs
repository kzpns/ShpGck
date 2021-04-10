using System;
using ShpGck.Tcp;
using ShpGck.CafeCode;

namespace ShpGck.Example.CodeSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Wii U's IPv4> ");
            string wiiuIp = Console.ReadLine();

            Console.WriteLine("Connecting TCPGecko server...");
            TcpGeckoConnector connector = new TcpGeckoConnector();
            connector.Connect(wiiuIp);
            Console.Write("Connected!");

            Console.Write("Sending codes...");
            GeckoClient client = new GeckoClient(connector);
            //client.CodeHandler.SendCodes()
            //new CCWriteMemory(0x1004F71C, 0, ValueSize.UInt8) //Home Button Menu Anywhere [Macopride64])
            client.Connector.Disconnect();
            Console.WriteLine("Sent!");
            Console.WriteLine("You can use the Home Menu in anywhere.");

            Console.ReadKey(false);
        }
    }
}
