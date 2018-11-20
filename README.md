# ShpGck
A library for [BullyWiiPlaza's TCPGecko](https://github.com/BullyWiiPlaza/tcpgecko) using .NET <br>
Code based on [TCP Gecko dotNet](https://github.com/Chadderz121/tcp-gecko-dotnet)

## Example
```csharp
using System;
using ShpGck;
using ShpGck.CafeCode;

namespace CodeSender
{
  public static class Program
  {
    public static Main(string[] args)
    {
      GckGeckoU gecko = new GckGeckoU();
      Console.WriteLine("Connecting to tcpgecko server...");
      gecko.Connect("192.168.1.1");
      Console.WriteLine("Connected!");
      
      Console.WriteLine("Sending code...");
      gecko.SendCodes(
        new CafeCodeWriteMemory(0x1004F71C, 0, CCValueSize.UInt8) //Home Button Menu Anywhere [Macopride64]
      );
      Console.WriteLine("Sent code!");
      Console.ReadKey(false);
    }
  }
}
