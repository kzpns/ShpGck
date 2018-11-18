# ShpGck
A library for TCPGecko with C#

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
      Console.WriteLine("Connecting to tcpgecko server.");
      gecko.Connect("192.168.1.1");
      Console.WriteLine("Connected!");
      
      Console.WriteLine("Sending code...");
      gecko.SendCodes(
        new CafeCodeWriteMemory(0x1004F71C, (byte)0x00) //Home Button Menu Anywhere [Macopride64]
      );
      Console.WriteLine("Homebutton is enabling everywhere.");
      Console.ReadKey(false);
      gecko.ClearCodes();
      Console.WriteLine("Homebutton isn't enabling everywhere.");
      Console.ReadKey(false);
    }
  }
}
