using Deserialization;
using YahooAPI;

namespace Map
{
    public class Mapping
    {
        // On instancie les variables
        public double stockPrice;
        public double strike;
        public double expirationTime;
        public double volatility;

        public Mapping(string text)
        {
            Task.Run(async () =>
            {
                // On créer une insance de DataMarket
                DataMarket datamarket = new DataMarket();
                // On appelle JSONtoclass qui recupere le body d'une requete, et le deserialise dans la classe Root
                Root Myroot = await datamarket.JSONtoclass();


                int nombre = 1;
                if (text == "Call")
                {
                    // On récupere le nombre de contact grâce a la longueur de la liste
                    int testc = Myroot.optionChain.result[0].options[0].calls.Count();

                    // On saisit un numéro de contrat
                    Console.Write($"Quel contrat : (1 à {testc}) : ");
                    try
                    {
                        string saisie = Console.ReadLine();
                        nombre = int.Parse(saisie);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("La saisie n'est pas un nombre entier valide.");
                    }

                    // On transfere les données de la classe Root, dans cette classe Mapping
                    stockPrice = Myroot.optionChain.result[0].options[0].calls[nombre].lastPrice;
                    strike = Myroot.optionChain.result[0].options[0].calls[nombre].strike;
                    double tempExpirationTime = Myroot.optionChain.result[0].options[0].calls[nombre].expiration;
                    volatility = Myroot.optionChain.result[0].options[0].calls[nombre].impliedVolatility;

                    // On récupere la date grâce au timestamp que retourne l'API Yahoo
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
