using StockAnalyzer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace StockAnalyzer.Windows.Core.Services
{
    public interface IStockStreamService
    {
        // IAsyncEnumerable provides asynchronous iteration
        IAsyncEnumerable<StockPrice>   GetAllStockPrices(CancellationToken cancellationToken = default);
    }
}
