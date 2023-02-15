using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Diagnostics.Contracts;
using Deserialization;

namespace YahooAPI
{
    public class DataMarket
    {
        public async Task<string> GetDatasFromAPI()
        {
            var client = new HttpClient();
            Console.Write("Symbole de l'option : ");
            string symbol = Console.ReadLine();
            string expiration = "1705622400";
            string url = string.Format("https://yahoo-finance15.p.rapidapi.com/api/yahoo/op/option/{0}?expiration={1}", symbol, expiration);;
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
                {
                    { "X-RapidAPI-Key", "7317af99d1mshc38280fcd368d36p11c444jsnf8830c0b085a" },
                    { "X-RapidAPI-Host", "yahoo-finance15.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        public async Task<Root> JSONtoclass()
        {
            DataMarket datamarket = new DataMarket();
            var jsonBody = await datamarket.GetDatasFromAPI();

            Root Myroot = JsonConvert.DeserializeObject<Root>(jsonBody);
            return Myroot;
        }

    }
}