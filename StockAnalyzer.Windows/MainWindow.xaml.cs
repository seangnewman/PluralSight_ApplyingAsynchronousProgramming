using Newtonsoft.Json;
using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;
using StockAnalyzer.Core.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace StockAnalyzer.Windows
{
    public partial class MainWindow : Window
    {
        private static readonly string API_URL = "https://ps-async.fekberg.com/api/stocks";
        private readonly Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }

        CancellationTokenSource cancellationTokenSource;

         private async void Search_Click(object sender, RoutedEventArgs e)
        //private void Search_Click(object sender, RoutedEventArgs e)
        {

            //BeforeLoadingStockData();
            #region asynchronous call must be replaced with asynchronous HttpClient
            //var client = new WebClient();

            //var content = client.DownloadString($"{API_URL}/{StockIdentifier.Text}");

            //// Simulate that the web call takes a very long time
            //Thread.Sleep(10000);


            #endregion

            #region using HttpClient
            //using (var client = new HttpClient())
            //{
            //    var responseTask = client.GetAsync($"{API_URL}/{StockIdentifier.Text}");

            //    var response = await responseTask;

            //    var content = await response.Content.ReadAsStringAsync();

            //    var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);

            //    Stocks.ItemsSource = data;
            //}
            #endregion
            #region using the DataStore

            //try
            //{
            //    var store = new DataStore();
            //    var responseTask = store.GetStockPrices(StockIdentifier.Text);
            //    Stocks.ItemsSource = await responseTask;
            //}
            //catch (Exception ex)
            //{
            //    Notes.Text += ex.Message;
            //}

            #endregion
            #region IntroducingAsynchronous Methods
            // Return the Task
            //var getStocksTask = GetStocks();
            // returned Task needs to be awaited 
            // await getStocksTask;
            #endregion
            #region catching exceptions
            //try
            //{
            //    BeforeLoadingStockData();
            //    await GetStocks();   // validate no exceptions in async operations
            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{
            //    AfterLoadingStockData();
            //}

            #endregion

            #region Introducing Tasks

            //try
            //{
            //    BeforeLoadingStockData();

            //    var lines = File.ReadAllLines("StockPrices_Small.csv");
            //    var data = new List<StockPrice>();
            //    foreach (var line in lines.Skip(1))
            //    {
            //        var price = StockPrice.FromCSV(line);
            //        data.Add(price);
            //    }

            //    Stocks.ItemsSource = data.Where(sp => sp.Identifier == StockIdentifier.Text);
            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{
            //    AfterLoadingStockData();
            //}

            #endregion

            #region CreatingAsynchronousOperations
            //try
            //{
            //    BeforeLoadingStockData();

            //    // Queue work to the thread pool
            //    await Task.Run(() =>
            //    {
            //        var lines = File.ReadAllLines("StockPrices_Small.csv");
            //        var data = new List<StockPrice>();
            //        foreach (var line in lines.Skip(1))
            //        {
            //            var price = StockPrice.FromCSV(line);
            //            data.Add(price);
            //        }
            //        Dispatcher.Invoke( () => {
            //            Stocks.ItemsSource = data.Where(sp => sp.Identifier == StockIdentifier.Text);
            //        });

            //    });

            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{
            //    AfterLoadingStockData();
            //}
            #endregion

            #region Obtaining the Result of the Task
            //try
            //{
            //    BeforeLoadingStockData();

            //    // Queue work to the thread pool
            //    var loadLinesTask = Task.Run(() =>
            //   {
            //       var lines = File.ReadAllLines("StockPrices_Small.csv");
            //       return lines;




            //   });

            //    var processsStocksTask = loadLinesTask.ContinueWith((completedTask) =>
            //    {

            //        // We can use Result because this is a continuation and occurs after the previous task has completed.
            //        var lines = completedTask.Result;

            //        var data = new List<StockPrice>();
            //        foreach (var line in lines.Skip(1))
            //        {
            //            var price = StockPrice.FromCSV(line);
            //            data.Add(price);
            //        }
            //        Dispatcher.Invoke(() =>
            //        {
            //            Stocks.ItemsSource = data.Where(sp => sp.Identifier == StockIdentifier.Text);
            //        });
            //    });

            //    processsStocksTask.ContinueWith(_ =>
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            AfterLoadingStockData();
            //        });

            //    });

            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{

            //}
            #endregion

            #region NestedAsynchronousOperations
            //try
            //{
            //    BeforeLoadingStockData();

            //    // Queue work to the thread pool
            //    var loadLinesTask = Task.Run(async () =>
            //   {
            //       using (var stream = new StreamReader(File.OpenRead("StockProces_Small.csv")))
            //       {
            //           var lines = new List<string>();
            //           string line;
            //           while ((line = await stream.ReadLineAsync()) != null)
            //           {
            //               lines.Add(line);
            //           }
            //           return lines;

            //       }

            //   });

            //    var processsStocksTask = loadLinesTask.ContinueWith((completedTask) =>
            //    {

            //        // We can use Result because this is a continuation and occurs after the previous task has completed.
            //        var lines = completedTask.Result;

            //        var data = new List<StockPrice>();
            //        foreach (var line in lines.Skip(1))
            //        {
            //            var price = StockPrice.FromCSV(line);
            //            data.Add(price);
            //        }
            //        Dispatcher.Invoke(() =>
            //        {
            //            Stocks.ItemsSource = data.Where(sp => sp.Identifier == StockIdentifier.Text);
            //        });
            //    });

            //    processsStocksTask.ContinueWith(_ =>
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            AfterLoadingStockData();
            //        });

            //    });

            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{

            //}
            #endregion

            #region Handling Task success and failure
            //try
            //{
            //    BeforeLoadingStockData();

            //    // Queue work to the thread pool
            //    var loadLinesTask = Task.Run(async () =>
            //    {
            //        using (var stream = new StreamReader(File.OpenRead("StockProces_Small.csv")))
            //        {
            //            var lines = new List<string>();
            //            string line;
            //            while ((line = await stream.ReadLineAsync()) != null)
            //            {
            //                lines.Add(line);
            //            }
            //            return lines;

            //        }

            //    });

            //    loadLinesTask.ContinueWith(t =>
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            Notes.Text = t.Exception.InnerException.Message;
            //        });
            //    }, TaskContinuationOptions.OnlyOnFaulted);

            //    var processsStocksTask = loadLinesTask.ContinueWith(t =>
            //    {
            //        // Log Something
            //        return t.Result;
            //    }).ContinueWith((completedTask) =>
            //   {

            //        // We can use Result because this is a continuation and occurs after the previous task has completed.
            //        var lines = completedTask.Result;

            //       var data = new List<StockPrice>();
            //       foreach (var line in lines.Skip(1))
            //       {
            //           var price = StockPrice.FromCSV(line);
            //           data.Add(price);
            //       }
            //       Dispatcher.Invoke(() =>
            //       {
            //           Stocks.ItemsSource = data.Where(sp => sp.Identifier == StockIdentifier.Text);
            //       });
            //   }, TaskContinuationOptions.OnlyOnRanToCompletion);

            //    processsStocksTask.ContinueWith(_ =>
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            AfterLoadingStockData();
            //        });

            //    });

            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{

            //}
            #endregion

            #region Cancellation and Stopping a Task
            //  if(cancellationTokenSource != null)
            //{
            //    //Already have an instance of the cancellation token source?
            //    //This means the button has previously been pressed
            //    cancellationTokenSource.Cancel();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search";
            //    return;
            //}
            //   try
            //{
            //    cancellationTokenSource = new CancellationTokenSource();

            //    cancellationTokenSource.Token.Register( () => {
            //        Notes.Text = "Cancellation Requested";
            //    });

            //    Search.Content = "Cancel"; // Sets the button text

            //    BeforeLoadingStockData();

            //    // Queue work to the thread pool
            //    Task<List<string>> loadLinesTask = SearchForStocks(cancellationTokenSource.Token);

            //    loadLinesTask.ContinueWith(t =>
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            Notes.Text = t.Exception.InnerException.Message;
            //        });
            //    }, TaskContinuationOptions.OnlyOnFaulted);

            //    var processsStocksTask = loadLinesTask.ContinueWith(t =>
            //    {
            //        // Log Something
            //        return t.Result;
            //    }).ContinueWith((completedTask) =>
            //    {

            //        // We can use Result because this is a continuation and occurs after the previous task has completed.
            //        var lines = completedTask.Result;

            //        var data = new List<StockPrice>();
            //        foreach (var line in lines.Skip(1))
            //        {
            //            var price = StockPrice.FromCSV(line);
            //            data.Add(price);
            //        }
            //        Dispatcher.Invoke(() =>
            //        {
            //            Stocks.ItemsSource = data.Where(sp => sp.Identifier == StockIdentifier.Text);
            //        });
            //    }, TaskContinuationOptions.OnlyOnRanToCompletion);

            //    processsStocksTask.ContinueWith(_ =>
            //    {
            //        Dispatcher.Invoke(() =>
            //        {
            //            AfterLoadingStockData();
            //            cancellationTokenSource = null;
            //            Search.Content = "Search"; // We are on the UI thread, so set the button text
            //        });

            //    });

            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{

            //}
            #endregion

            #region Cancellation with HttpClient
            //if (cancellationTokenSource != null)
            //{
            //    //Already have an instance of the cancellation token source?
            //    //This means the button has previously been pressed
            //    cancellationTokenSource.Cancel();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search";
            //    return;
            //}
            //try
            //{
            //    cancellationTokenSource = new CancellationTokenSource();

            //    cancellationTokenSource.Token.Register(() => {
            //        Notes.Text = "Cancellation Requested";
            //    });

            //    Search.Content = "Cancel"; // Sets the button text

            //    BeforeLoadingStockData();

            //    var service = new StockService();
            //    var data = await service.GetStockPricesFor(StockIdentifier.Text, cancellationTokenSource.Token);
            //    Stocks.ItemsSource = data;


            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{
            //    AfterLoadingStockData();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search"; // We are on the UI thread, so set the button text
            //}
            //#endregion
            //#region Exploring Task Parallel Library 
            //if (cancellationTokenSource != null)
            //{
            //    //Already have an instance of the cancellation token source?
            //    //This means the button has previously been pressed
            //    cancellationTokenSource.Cancel();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search";
            //    return;
            //}
            //try
            //{
            //    cancellationTokenSource = new CancellationTokenSource();

            //    cancellationTokenSource.Token.Register(() => {
            //        Notes.Text = "Cancellation Requested";
            //    });

            //    Search.Content = "Cancel"; // Sets the button text

            //    BeforeLoadingStockData();

            //    var service = new StockService();
            //    var data = await service.GetStockPricesFor(StockIdentifier.Text, cancellationTokenSource.Token);
            //    Stocks.ItemsSource = data;


            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{
            //    AfterLoadingStockData();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search"; // We are on the UI thread, so set the button text
            //}

            #endregion

            #region Knowing when all or any tasks  completes
            //if (cancellationTokenSource != null)
            //{
            //    //Already have an instance of the cancellation token source?
            //    //This means the button has previously been pressed
            //    cancellationTokenSource.Cancel();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search";
            //    return;
            //}
            //try
            //{
            //    cancellationTokenSource = new CancellationTokenSource();
            //    //cancellationTokenSource.CancelAfter(1000);

            //    cancellationTokenSource.Token.Register(() => {
            //        Notes.Text = "Cancellation Requested";
            //    });

            //    Search.Content = "Cancel"; // Sets the button text

            //    BeforeLoadingStockData();
            //    var identifiers = StockIdentifier.Text.Split(',', ' ');

            //    var service = new StockService();

            //    var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();

            //    foreach (var identifier in identifiers)
            //    {
            //        // Add task for each stock, running in parallel
            //        var loadTask =  service.GetStockPricesFor(identifier, cancellationTokenSource.Token);
            //        loadingTasks.Add(loadTask);
            //    }

            //    var timeoutTask = Task.Delay(120000);
            //    var allStocksLoadingTask = Task.WhenAll(loadingTasks);

            //    var completedTask = await Task.WhenAny(timeoutTask, allStocksLoadingTask);

            //    if (completedTask == timeoutTask)
            //    {
            //        cancellationTokenSource.Cancel();
            //        throw new OperationCanceledException("Timeout!");
            //    }

               

            //    Stocks.ItemsSource = allStocksLoadingTask.Result.SelectMany(x => x);


            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{
            //    AfterLoadingStockData();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search"; // We are on the UI thread, so set the button text
            //}

            #endregion

            #region Precomputed Results of a Task
            //if (cancellationTokenSource != null)
            //{
            //    //Already have an instance of the cancellation token source?
            //    //This means the button has previously been pressed
            //    cancellationTokenSource.Cancel();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search";
            //    return;
            //}
            //try
            //{
            //    cancellationTokenSource = new CancellationTokenSource();
            //    //cancellationTokenSource.CancelAfter(1000);

            //    cancellationTokenSource.Token.Register(() => {
            //        Notes.Text = "Cancellation Requested";
            //    });

            //    Search.Content = "Cancel"; // Sets the button text

            //    BeforeLoadingStockData();
            //    var identifiers = StockIdentifier.Text.Split(',', ' ');

            //    var service = new MockStockService();

            //    var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();

            //    foreach (var identifier in identifiers)
            //    {
            //        // Add task for each stock, running in parallel
            //        var loadTask = service.GetStockPricesFor(identifier, cancellationTokenSource.Token);
            //        loadingTasks.Add(loadTask);
            //    }

            //    var timeoutTask = Task.Delay(120000);
            //    var allStocksLoadingTask = Task.WhenAll(loadingTasks);

            //    var completedTask = await Task.WhenAny(timeoutTask, allStocksLoadingTask);

            //    if (completedTask == timeoutTask)
            //    {
            //        cancellationTokenSource.Cancel();
            //        throw new OperationCanceledException("Timeout!");
            //    }



            //    Stocks.ItemsSource = allStocksLoadingTask.Result.SelectMany(x => x);


            //}
            //catch (Exception ex)
            //{

            //    Notes.Text = ex.Message;
            //}
            //finally
            //{
            //    AfterLoadingStockData();
            //    cancellationTokenSource = null;
            //    Search.Content = "Search"; // We are on the UI thread, so set the button text
            //}

            #endregion

            #region Process Tasks as they complete
            if (cancellationTokenSource != null)
            {
                //Already have an instance of the cancellation token source?
                //This means the button has previously been pressed
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                Search.Content = "Search";
                return;
            }
            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                //cancellationTokenSource.CancelAfter(1000);

                cancellationTokenSource.Token.Register(() => {
                    Notes.Text = "Cancellation Requested";
                });

                Search.Content = "Cancel"; // Sets the button text

                BeforeLoadingStockData();
                var identifiers = StockIdentifier.Text.Split(',', ' ');

                var service = new StockService();

                var loadingTasks = new List<Task<IEnumerable<StockPrice>>>();

                var stocks = new ConcurrentBag<StockPrice>();

                foreach (var identifier in identifiers)
                {
                    // Add task for each stock, running in parallel
                    var loadTask = service.GetStockPricesFor(identifier, cancellationTokenSource.Token);

                    loadTask = loadTask.ContinueWith( t => {
                        var aFewStocks = t.Result.Take(2);

                        foreach (var stock in aFewStocks)
                        {
                            stocks.Add(stock);
                        }

                        Dispatcher.Invoke( () => {
                            Stocks.ItemsSource = stocks.ToArray();
                        });
                        return aFewStocks;
                    });
                    
                    
                    loadingTasks.Add(loadTask);
                }

                var timeoutTask = Task.Delay(120000);
                var allStocksLoadingTask = Task.WhenAll(loadingTasks);

                var completedTask = await Task.WhenAny(timeoutTask, allStocksLoadingTask);

                if (completedTask == timeoutTask)
                {
                    cancellationTokenSource.Cancel();
                    throw new OperationCanceledException("Timeout!");
                }



               // Stocks.ItemsSource = allStocksLoadingTask.Result.SelectMany(x => x);


            }
            catch (Exception ex)
            {

                Notes.Text = ex.Message;
            }
            finally
            {
                AfterLoadingStockData();
                cancellationTokenSource = null;
                Search.Content = "Search"; // We are on the UI thread, so set the button text
            }
            #endregion

            //AfterLoadingStockData();
        }

        private static Task<List<string>> SearchForStocks(CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                using (var stream = new StreamReader(File.OpenRead("StockPrices_Small.csv")))
                {
                    var lines = new List<string>();
                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            break;
                        }
                        lines.Add(line);
                    }
                    return lines;

                }

            }, cancellationToken);
        }

        private async Task GetStocks()
        // The Task returned from an async method is a reference to the operation,  the result of the operation or potential errors
        {
            try
            {
                var store = new DataStore();
                var responseTask = store.GetStockPrices(StockIdentifier.Text);
                Stocks.ItemsSource = await responseTask;
            }
            catch (Exception ex)
            {
                // Because the await keyword was used, this continuation throws the exception to the calling thread
                // otherwise it is swallowed by the Task
                //Notes.Text += ex.Message;
                throw ex;
            }
        }

        private void BeforeLoadingStockData()
        {
            stopwatch.Restart();
            StockProgress.Visibility = Visibility.Visible;
            StockProgress.IsIndeterminate = true;
        }

        private void AfterLoadingStockData()
        {
            StocksStatus.Text = $"Loaded stocks for {StockIdentifier.Text} in {stopwatch.ElapsedMilliseconds}ms";
            StockProgress.Visibility = Visibility.Hidden;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            e.Handled = true;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
