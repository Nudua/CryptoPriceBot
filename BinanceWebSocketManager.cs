using Binance.Net;
using System;
using System.Threading.Tasks;

namespace CryptoPriceBot
{
    public class BinanceWebsocketManager
    {
        public async Task<bool> ConnectAndSubscribeAsync()
        {
            var client = new BinanceSocketClient();

            var connectResult = await client.Spot.SubscribeToSymbolTickerUpdatesAsync("BTCUSDT", (tickData) =>
            {
                Console.WriteLine($"Last price for Bitcoin is: {tickData.LastPrice}");
            });

            return connectResult.Success;
        }
    }
}