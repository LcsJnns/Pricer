using Function;
using Graphic;
using Map;

namespace PricerProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Call ou Put ?
            Console.Write("Call ou Put : ");
            string text = Console.ReadLine();
            

            // On récupere les données à l'API
            Mapping mapping = new Mapping(text);

            // Affiche les données
            Console.WriteLine("Stock Price : " + 300);
            Console.WriteLine("Strike : " + 250);
            Console.WriteLine("Expiration date : " + 1);
            Console.WriteLine("Volatility : " + 0.15);
            Console.WriteLine("Risk - Free Interest Rate : " + 0.03);

            double callPrice = Black_Scholes.Call_Pricing(300, 250, 1, 0.03, 0.15);
            Console.WriteLine($"Call price = {callPrice}");

            double putPrice = Black_Scholes.Put_Pricing(300, 250, 1, 0.03, 0.15);
            Console.WriteLine($"Put price = {putPrice}");

            // Créer les graphes pour Call ou Put
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