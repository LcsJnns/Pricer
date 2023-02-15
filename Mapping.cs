using Deserialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooAPI;

namespace Map
{
    public class Mapping
    {
        public double stockPrice;
        public double strike;
        public double expirationTime;
        public double volatility;

        public Mapping(string text)
        {
            Task.Run(async () =>
            {
                DataMarket datamarket = new DataMarket();
                Root Myroot = await datamarket.JSONtoclass();


                

                int nombre = 1;
                if (text == "Call")
                {
                    int testc = Myroot.optionChain.result[0].options[0].calls.Count();
                    Console.Write($"Quel contrat : (1 à {testc}) : ");
                    try
                    {
                        string saisie = Console.ReadLine();
                        nombre = int.Parse(saisie);

                        Console.WriteLine("Vous avez saisi le nombre : " + nombre);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("La saisie n'est pas un nombre entier valide.");
                    }
                    stockPrice = Myroot.optionChain.result[0].options[0].calls[nombre].lastPrice;
                    strike = Myroot.optionChain.result[0].options[0].calls[nombre].strike;
                    double tempExpirationTime = Myroot.optionChain.result[0].options[0].calls[nombre].expiration;
                    volatility = Myroot.optionChain.result[0].options[0].calls[nombre].impliedVolatility;

                    DateTime today = DateTime.Now;
                    double timestamp = (long)(today - new DateTime(1970, 1, 1)).TotalSeconds;
                    tempExpirationTime -= timestamp;
                    expirationTime = tempExpirationTime / 31536000;
                }
                else if (text == "Put")
                {
                    int testc = Myroot.optionChain.result[0].options[0].puts.Count();
                    Console.Write($"Quel contrat : (1 à {testc}) : ");
                    try
                    {
                        string saisie = Console.ReadLine();
                        nombre = int.Parse(saisie);

                        Console.WriteLine("Vous avez saisi le nombre : " + nombre);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("La saisie n'est pas un nombre entier valide.");
                    }
                    stockPrice = Myroot.optionChain.result[0].options[0].puts[nombre].lastPrice;
                    strike = Myroot.optionChain.result[0].options[0].puts[nombre].strike;
                    double tempExpirationTime = Myroot.optionChain.result[0].options[0].puts[nombre].expiration;
                    volatility = Myroot.optionChain.result[0].options[0].puts[nombre].impliedVolatility;

                    DateTime today = DateTime.Now;
                    double timestamp = (long)(today - new DateTime(1970, 1, 1)).TotalSeconds;
                    tempExpirationTime -= timestamp;
                    expirationTime = tempExpirationTime / 31536000;
                }
                else
                {
                    Environment.Exit(0);
                }

            }).Wait();
        }
    }
}
