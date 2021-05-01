using Binance.Net.Interfaces;
using CryptoPriceBot.Notifications;
using System;
using System.Collections.Generic;

namespace CryptoPriceBot.Analyzers
{
    public class PriceAboveAnalyzer : IPriceAnalyzer
    {
        private bool _hasFired = false;
        private readonly List<INotificationService> _services;

        private readonly decimal _abovePrice;

        // Implement the symbol property because the manager needs to know which symbols to subscribe to
        public string Symbol { get; }

        public PriceAboveAnalyzer(string symbol, decimal abovePrice, List<INotificationService> services)
        {
            Symbol = symbol;
            _abovePrice = abovePrice;
            // New
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public void OnUpdate(IBinanceTick tick)
        {
            if (!_hasFired && tick.LastPrice > _abovePrice)
            {
                _hasFired = true;

                var message = $"The price of {Symbol} is above {_abovePrice}! Price: {tick.LastPrice}";

                foreach (var service in _services)
                {
                    // Todo: Verify that the email was actually sent.
                    service.Notify(message);
                }

                Console.WriteLine(message);
            }
        }
    }
}