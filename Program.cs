using CryptoPriceBot;
using CryptoPriceBot.Analyzers;
using CryptoPriceBot.Notifications;
using System;

Console.WriteLine("Starting bot...");

var manager = new BinanceWebSocketManager(new()
{
    new PriceAboveAnalyzer("BTCUSDT", 55300, new()
    {
        new SmtpEmailNotificationService("my-email@outlook.com")
    }),
    new PriceAboveAnalyzer("ETHUSDT", 2529, new()
    {
        new SmtpEmailNotificationService("my-email@outlook.com")
    })
});

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