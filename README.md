# ShpGck
A library for [BullyWiiPlaza's TCPGecko](https://github.com/BullyWiiPlaza/tcpgecko) using .NET <br>
Code based on [TCP Gecko dotNet](https://github.com/Chadderz121/tcp-gecko-dotnet), [pyGecko](https://github.com/wiiudev/pyGecko)

## Example
```csharp
using System;
using ShpGck.CafeCode;

namespace ShpGck.Example.CodeSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Wii U's IPv4> ");
            string ip_addr = Console.ReadLine();

            GckGeckoU gck = new GckGeckoU();
            Console.WriteLine("Connecting tcpgecko server...");
            gck.Connect(ip_addr);
            Console.WriteLine("Connected!");

            Console.WriteLine("Sending codes...");
            gck.SendCodes(
                new CCWriteMemory(0x1004F71C, 0, ValueSize.UInt8) //Home Button Menu Anywhere [Macopride64])
                );
            Console.WriteLine("Sent!");
			Console.WriteLine("You can use the Home Menu in anywhere."); 

            Console.ReadKey(false);
        }
    }
}
```