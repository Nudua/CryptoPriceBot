using Binance.Net;
using CryptoPriceBot.Analyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoPriceBot
{
    public class BinanceWebSocketManager
    {
        private readonly BinanceSocketClient _client;
        private readonly List<IPriceAnalyzer> _priceAnalyzers;

        public BinanceWebSocketManager(List<IPriceAnalyzer> priceAnalyzers)
        {
            // Throw an exception if the list is null
            _priceAnalyzers = priceAnalyzers ?? throw new ArgumentNullException(nameof(priceAnalyzers));
            _client = new BinanceSocketClient();
        }

        public async Task<bool> ConnectAndSubscribeAsync()
        {
            // Iterate over a list of all the unique Symbols to watch for price changes
            foreach (var symbol in _priceAnalyzers.Select(x => x.Symbol).Distinct())
            {
                // Subscribe to the WebSocket stream for the Symbol
                var result = await _client.Spot.SubscribeToSymbolTickerUpdatesAsync(symbol, (tickData) =>
                {
                    foreach (var analyzer in _priceAnalyzers)
                    {
                        // Call update if the symbol matches the current subscription
                        if (analyzer.Symbol == symbol)
                        {
                            analyzer.OnUpdate(tickData);
                        }
                    }
                });

                if (!result.Success)
                {
                    // If one of the subscriptions fail to connect, we just cleanup and return false
                    await _client.UnsubscribeAll();
                    return false;
                }
            }

            return true;
        }
    }
}