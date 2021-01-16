using Newtonsoft.Json;
using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static string API_URL = "https://ps-async.fekberg.com/api/stocks";
        private Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }



        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            BeforeLoadingStockData();
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
            var getStocksTask =  GetStocks();
            // returned Task needs to be awaited 
            await getStocksTask;
            #endregion
            AfterLoadingStockData();
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
                Notes.Text += ex.Message;
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
