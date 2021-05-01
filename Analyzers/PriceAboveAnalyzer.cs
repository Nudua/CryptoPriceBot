using Binance.Net.Interfaces;
using System;

namespace CryptoPriceBot.Analyzers
{
    public class PriceAboveAnalyzer : IPriceAnalyzer
    {
        private readonly decimal _abovePrice;

        // Implement the symbol property because the manager needs to know which symbols to subscribe to
        public string Symbol { get; }

        public PriceAboveAnalyzer(string symbol, decimal abovePrice)
        {
            Symbol = symbol;
            _abovePrice = abovePrice;
        }

        public void OnUpdate(IBinanceTick tick)
        {
            // For now let's just write to the console once our condition is met
            // We'll change this to send an email in the next section once
            // we've implemented a notification service for it
            if (tick.LastPrice > _abovePrice)
            {
                Console.WriteLine($"The price of {Symbol} is above {_abovePrice}! Price: {tick.LastPrice}");
            }
        }
    }
}