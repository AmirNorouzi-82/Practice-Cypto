using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net;

namespace Practice_3
{
    internal class Program
    {
        static void Main()
        {
            string url = "https://api.coingecko.com/api/v3/coin/markets";
            string vsCurrency = "usd";
            string ids = "bitcoin,ethereum,tether";
            string apiUrl = $"{url}?VS_Currency={vsCurrency}&Ids={ids}";
            using (WebClient client = new WebClient())
            {
                try 
                {
                string jsonResponse = client.DownloadString(apiUrl);
                 List<CoinMarketData> marketData = JsonConvert.DeserializeObject<List<CoinMarketData>>(jsonResponse);
                    foreach (CoinMarketData data in marketData)
                    {
                        Console.WriteLine($"Coin: {data.Name}");
                        Console.WriteLine($"Price:{data.CurrentPrice} {vsCurrency}");
                        Console.WriteLine($"Market Cap;{data.MarketCap}{vsCurrency}");
                        Console.WriteLine($"Total Volume:{data.TotalVolume}{vsCurrency}");
                        Console.WriteLine();
                    }
         
                }
                catch ( Exception ex )
                {
                    Console.WriteLine("An error occured: " + ex.Message);
                }
            }
            Console.Read();
        }
    }
}
     public class CoinMarketData
     { 
      public string Id { get; set; }
      public string Symbol { get; set; }
      public string Name { get; set; }
      public decimal CurrentPrice { get; set; }
      public decimal MarketCap { get; set; }
      public decimal TotalVolume  { get; set;}

     
        }

