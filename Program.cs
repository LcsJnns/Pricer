using Function;
using Graphic;
using Map;
using System.Net.NetworkInformation;

namespace PricerProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call ou Put ?
            Console.Write("Call ou Put : ");
            string text = Console.ReadLine().ToLower();

            // On récupere les données à l'API
            Mapping mapping = new Mapping(text);

            // Affiche les données
            Console.WriteLine("Stock Price : " + mapping.stockPrice);
            Console.WriteLine("Strike : " + mapping.strike);
            Console.WriteLine("Expiration date : " + mapping.expirationTime);
            Console.WriteLine("Volatility : " + mapping.volatility);
            Console.WriteLine("Risk - Free Interest Rate : " + 0.03);

            double callPrice = Black_Scholes.Call_Pricing(mapping.stockPrice, mapping.strike, mapping.expirationTime, 0.03, mapping.volatility);
            Console.WriteLine($"Call price = {callPrice}");

            double putPrice = Black_Scholes.Put_Pricing(mapping.stockPrice, mapping.strike, mapping.expirationTime, 0.03, mapping.volatility);
            Console.WriteLine($"Put price = {putPrice}");

            // Créer les graphes pour Call ou Put
            Graphe gc = new Graphe();
            if (text == "call")
            {
                gc.CreateCallGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateCallPriceGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateDeltaGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateGammaGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateThetaGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateVegaGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateRhoGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);

            }
            else if (text =="put")
            {
                gc.CreatePutGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreatePutPriceGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateDeltaGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateGammaGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateThetaGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateVegaGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
                gc.CreateRhoGraphe(mapping.stockPrice, mapping.strike, mapping.expirationTime, mapping.volatility);
            }
        }

    }

}