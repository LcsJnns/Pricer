using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Function;
using System.Net.Http;
using YahooAPI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Deserialization;
using System.Drawing;
using Graphic;
using Map;

namespace PricerProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Call ou Put : ");
            string text = Console.ReadLine();

            Mapping mapping = new Mapping(text);
            Console.WriteLine("Stock Price : " + mapping.stockPrice);
            Console.WriteLine("strike : " + mapping.strike);
            Console.WriteLine("expiration date : " + mapping.expirationTime);
            Console.WriteLine("volatility : " + mapping.volatility);

            double callPrice = Black_Scholes.Call_Pricing(mapping.stockPrice, mapping.strike, mapping.expirationTime, 0.03, mapping.volatility);
            Console.WriteLine($"Call price = {callPrice}");

            double putPrice = Black_Scholes.Put_Pricing(mapping.stockPrice, mapping.strike, mapping.expirationTime, 0.03, mapping.volatility);
            Console.WriteLine($"Put price = {putPrice}");

            Graphe gc = new Graphe();
            if (text == "Call")
            {
                gc.CreateCallGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
            }
            else if (text =="Put")
            {
                gc.CreatePutGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
            }
        }

    }

}