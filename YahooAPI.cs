using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Deserialization;

namespace YahooAPI
{
    public class DataMarket
    {
        public async Task<string> GetDatasFromAPI()
        {
            // On crééer une instance de HttpClient pour pouvoir faire une requete protocole Http
            var client = new HttpClient();

            // On récupere le Symbole de l'option qu'on met dans l'URL
            Console.Write("Symbole de l'option : ");
            string symbol = Console.ReadLine();

            // Date d'expiration
            string expiration = "1705622400";
            // Construit une URL de requête à partir du symbole de l'option et de la date d'expiration, à l'aide de la méthode string.Format.
            // Cette URL est utilisée pour accéder à l'API Yahoo Finance.
            string url = string.Format("https://yahoo-finance15.p.rapidapi.com/api/yahoo/op/option/{0}?expiration={1}", symbol, expiration);

            // Créer une instance de requete Http
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

            // Envoie la requête HTTP à l'API Yahoo Finance à l'aide de la méthode SendAsync
            using (var response = await client.SendAsync(request))
            {
                // On vérifie que la requete est valide
                response.EnsureSuccessStatusCode();
                // On récupère le corps de la réponse Http
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        public async Task<Root> JSONtoclass()
        {
            // On récupere le json de la requete avec la fonction GetDatasFromAPI
            DataMarket datamarket = new DataMarket();
            var jsonBody = await datamarket.GetDatasFromAPI();

            // On deserialise
            Root Myroot = JsonConvert.DeserializeObject<Root>(jsonBody);
            return Myroot;
        }

    }
}