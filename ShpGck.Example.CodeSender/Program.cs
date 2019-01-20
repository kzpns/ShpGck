using System;
using ShpGck.CafeCode;

namespace ShpGck.Example.CodeSender
{
    class Program
    {
        static void Main(string[] args)
        {
            GckGeckoU gck = new GckGeckoU();
            Console.Write("Wii U's IP> ");
            string ip_addr = Console.ReadLine();
            Console.WriteLine("Connecting tcpgecko server...");
            gck.Connect(ip_addr);
            Console.WriteLine("Connected!");

            Console.WriteLine("Sending codes...");
            gck.SendCodes(
                new CCWriteMemoryCode(0x1004F71C, 0, ValueSize.UInt8) //Home Button Menu Anywhere [Macopride64])
                );
            Console.WriteLine("Sent!");

            Console.ReadKey(false);
        }
    }
}
