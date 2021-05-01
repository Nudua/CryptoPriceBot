using CryptoPriceBot;
using System;

Console.WriteLine("Starting bot...");

var manager = new BinanceWebsocketManager();

// Try connecting and subscribing for updates for Bitcoin price updates
if (!await manager.ConnectAndSubscribeAsync())
{
    Console.WriteLine("Unable to connect to websocket, quitting...");
    return;
}

// Keep the bot running until the user presses the 'q' key
while (true)
{
    var keyInfo = Console.ReadKey();

    if (keyInfo.Key == ConsoleKey.Q)
    {
        break;
    }
}