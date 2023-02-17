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
            Console.WriteLine("Stock Price : " + 300);
            Console.WriteLine("strike : " + 250);
            Console.WriteLine("expiration date : " + 1);
            Console.WriteLine("volatility : " + 0.15);

            double callPrice = Black_Scholes.Call_Pricing(300, 250, 1, 0.03, 0.15);
            Console.WriteLine($"Call price = {callPrice}");

            double putPrice = Black_Scholes.Put_Pricing(300, 250, 1, 0.03, 0.15);
            Console.WriteLine($"Put price = {putPrice}");

            Graphe gc = new Graphe();
            if (text == "Call")
            {
                gc.CreateCallGraphe(300, 250, 1, 0.15);
                gc.CreateCallPriceGraphe(300, 250, 1, 0.15);
                gc.CreateDeltaGraphe(300, 250, 1, 0.15);
                gc.CreateGammaGraphe(300, 250, 1, 0.15);
                gc.CreateThetaGraphe(300, 250, 1, 0.15);
                gc.CreateVegaGraphe(300, 250, 1, 0.15);
                gc.CreateRhoGraphe(300, 250, 1, 0.15);

            }
            else if (text =="Put")
            {
                gc.CreatePutGraphe(300, 250, 1, 0.15);
                gc.CreatePutPriceGraphe(300, 250, 1, 0.15);
                gc.CreateDeltaGraphe(300, 250, 1, 0.15);
                gc.CreateGammaGraphe(300, 250, 1, 0.15);
                gc.CreateThetaGraphe(300, 250, 1, 0.15);
                gc.CreateVegaGraphe(300, 250, 1, 0.15);
                gc.CreateRhoGraphe(300, 250, 1, 0.15);
            }
        }

    }

}