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

        public Mapping()
        {
            Task.Run(async () =>
            {
                DataMarket datamarket = new DataMarket();
                Root Myroot = await datamarket.JSONtoclass();

                stockPrice = Myroot.optionChain.result[0].options[0].calls[0].lastPrice;
                strike = Myroot.optionChain.result[0].options[0].calls[0].strike;
                double tempExpirationTime = Myroot.optionChain.result[0].options[0].calls[0].expiration;
                volatility = Myroot.optionChain.result[0].options[0].calls[0].impliedVolatility;

                DateTime today = DateTime.Now;
                double timestamp = (long)(today - new DateTime(1970, 1, 1)).TotalSeconds;
                tempExpirationTime -= timestamp;
                expirationTime = tempExpirationTime / 31536000;


            }).Wait();
        }
    }
}
