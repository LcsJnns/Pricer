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


            Mapping mapping = new Mapping();
            Console.WriteLine("Stock Price : " + mapping.stockPrice);
            Console.WriteLine("strike : " + mapping.strike);
            Console.WriteLine("expiration date : " + mapping.expirationTime);
            Console.WriteLine("volatility : " + mapping.volatility);

            double CallPrice = Black_Scholes.Call_Pricing(mapping.stockPrice, mapping.strike, mapping.expirationTime, 0.03, mapping.volatility);
            Console.WriteLine($"Call price = {CallPrice}");

            Graphe gc = new Graphe();
            gc.CreateGraphe();



        }

    }

}