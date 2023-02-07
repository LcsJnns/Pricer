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

namespace PricerProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {


            ////////////////////////////////////////

            // API Yahoo finance va donner ces valeurs
            double CoursAction = 120;
            double Strike = 120;
            double TauxSansRisque = 0.01;
            double Volatility = 0.3;
            double expirationTime = 1;
            // 

            double CallPrice = Black_Scholes.Call_Pricing(CoursAction, Strike, expirationTime, TauxSansRisque, Volatility);
            //Console.WriteLine($"Call price = {CallPrice}");

            double PutPrice = Black_Scholes.Put_Pricing(CoursAction, Strike, expirationTime, TauxSansRisque, Volatility);
            //Console.WriteLine("Put price = " + PutPrice);

            // Deserialisation du JSON
            DataMarket datamarket = new DataMarket();
            Root Myroot = await datamarket.JSONtoclass();

            CoursAction = Myroot.optionChain.result[0].options[0].calls[0].lastPrice;
            Strike = Myroot.optionChain.result[0].options[0].calls[0].strike;
            expirationTime = Myroot.optionChain.result[0].options[0].calls[0].expiration;
            Volatility = Myroot.optionChain.result[0].options[0].calls[0].impliedVolatility;

            Console.WriteLine(CoursAction);
            Console.WriteLine(Strike);
            Console.WriteLine(expirationTime);
            Console.WriteLine(Volatility);

            CallPrice = Black_Scholes.Call_Pricing(CoursAction, Strike, 0.5, TauxSansRisque, Volatility);
            Console.WriteLine($"Call price = {CallPrice}");



        }

    }

}