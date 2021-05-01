using Binance.Net.Interfaces;

namespace CryptoPriceBot.Analyzers
{
    public interface IPriceAnalyzer
    {
        // Each analyzer will be attached to a given symbol
        string Symbol { get; }

        void OnUpdate(IBinanceTick tick);
    }
}