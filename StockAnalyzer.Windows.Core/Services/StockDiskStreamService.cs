using StockAnalyzer.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace StockAnalyzer.Windows.Core.Services
{
    public class StockDiskStreamService : IStockStreamService
    {
        public async IAsyncEnumerable<StockPrice> GetAllStockPrices([EnumeratorCancellation]CancellationToken cancellationToken = default)
        {
            using var stream = new StreamReader(File.OpenRead("StockPrices_Small.csv"));

            await stream.ReadLineAsync(); // Skipping header row

            string line;

            while ((line = await stream.ReadLineAsync()) != null)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }

                yield return StockPrice.FromCSV(line);
            }
            
        }
    }
}
