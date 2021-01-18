using StockAnalyzer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockAnalyzer.Windows.Core.Services
{
    class MockStockStreamService : IStockStreamService
    {
        public async IAsyncEnumerable<StockPrice> GetAllStockPrices([EnumeratorCancellation]CancellationToken cancellationToken = default)
        {

            // Fakes that it will take 1/2 second to retrieve each item
            await Task.Delay(500, cancellationToken);
            yield return new StockPrice {Identifier = "MSFT",   Change =0.5m };
            await Task.Delay(500, cancellationToken);
            yield return new StockPrice { Identifier = "MSFT", Change = 0.2m };
            await Task.Delay(500, cancellationToken);
            yield return new StockPrice { Identifier = "GOOGL", Change = 0.3m };
            await Task.Delay(500, cancellationToken);
            yield return new StockPrice { Identifier = "GOOGL", Change = 0.8m };
        }
    }
}
