# ShpGck
A library for [BullyWiiPlaza's TCPGecko](https://github.com/BullyWiiPlaza/tcpgecko) using .NET <br>
Code based on [TCP Gecko dotNet](https://github.com/Chadderz121/tcp-gecko-dotnet)

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
      GckGeckoU gck = new GckGeckoU();
      Console.Write("Wii U's IP> ");
      string ip_addr = Console.ReadLine();
      Console.WriteLine("Connecting tcpgecko server...");
      gck.Connect(ip_addr);
     Console.WriteLine("Connected!");

      Console.WriteLine("Sending codes...");
      gck.SendCode(
        new CCWriteMemoryCode(0x1004F71C, 0, CCValueSize.UInt8) //Home Button Menu Anywhere [Macopride64])
      );
      Console.WriteLine("Sent!");

      Console.ReadKey(false);
    }
  }
}
