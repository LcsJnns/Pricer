using Function;
using ScottPlot;

namespace Graphic
{
    public class Graphe
    {
        public void CreateCallGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            // On créer une instance de Plot
            var plt = new Plot();

            // On récupere le prix de l'option
            double callPrice = Black_Scholes.Call_Pricing(stockPrice, strike, expirationTime, 0.03, volatility);

            // On créer les coordonnées des points dans 2 tableaux
            double[] xs = {  stockPrice/2,  strike ,  strike + callPrice,  strike + (2 * callPrice),  strike + (3 * callPrice) };
            double[] ys = { -callPrice, - callPrice, 0 , callPrice , 2* callPrice };


            plt.PlotHLine(0, color: System.Drawing.Color.Blue, lineWidth: 1);
            plt.PlotVLine( strike,label : $"At the money : { strike}", color: System.Drawing.Color.Red, lineWidth: 1);
            plt.PlotVLine( strike + callPrice,label : $"In the money : { strike + callPrice}" , color: System.Drawing.Color.Green, lineWidth: 1);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);

            // On ajoute la courbe et on sauvegarde l'image dans le dossier Images
            plt.AddScatter(xs, ys, color : System.Drawing.Color.Black);
            plt.SaveFig("Images/Black_Scholes_Call.png");
        }
        public void CreatePutGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            var plt = new Plot();

            
            double putPrice = Black_Scholes.Put_Pricing( stockPrice,  strike,  expirationTime, 0.03,  volatility);

            double[] xs = {0,  strike, 2* strike};
            double[] ys = {  strike - putPrice, -putPrice, -putPrice};


            plt.PlotHLine(0, color: System.Drawing.Color.Blue, lineWidth: 1);
            plt.PlotVLine( strike, label: $"At the money : { strike}", color: System.Drawing.Color.Red, lineWidth: 1);
            plt.PlotVLine( strike - putPrice, label: $"In the money : { strike - putPrice}", color: System.Drawing.Color.Green, lineWidth: 1);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);

            plt.AddScatter(xs, ys, color: System.Drawing.Color.Black);
            plt.SaveFig("Images/Black_Scholes_Put.png");
        }
        public void CreateCallPriceGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            double callPrice;

            var plt = new Plot();

            double[] xs = new double[Convert.ToInt32(stockPrice) * 2];
            double[] ys = new double[Convert.ToInt32(stockPrice) * 2];

            for (int i = 0; i < Convert.ToInt32(stockPrice) * 2; i++)
            {
                callPrice = Black_Scholes.Call_Pricing(i, strike, expirationTime, 0.03, volatility);

                xs[i] = i;
                ys[i] = callPrice;
            }

            plt.AddScatter(xs, ys, label: " Option value ", color: System.Drawing.Color.Black);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);
            plt.SaveFig("Images/Value_Of_Call_Option_Price.png");
        }

        public void CreatePutPriceGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            double putPrice;

            var plt = new Plot();

            double[] xs = new double[Convert.ToInt32(stockPrice) * 2];
            double[] ys = new double[Convert.ToInt32(stockPrice) * 2];

            for (int i = 0; i < Convert.ToInt32(stockPrice) * 2; i++)
            {
                putPrice = Black_Scholes.Put_Pricing(i, strike, expirationTime, 0.03, volatility);

                xs[i] = i;
                ys[i] = putPrice;
            }

            plt.AddScatter(xs, ys, label: " Option value ", color: System.Drawing.Color.Black);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);
            plt.SaveFig("Images/Value_Of_Put_Option_Price.png");
        }

        public void CreateDeltaGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            double d1;
            double delta;

            var plt = new Plot();
            
            double[] xs = new double[Convert.ToInt32(stockPrice) *2];
            double[] ys = new double[Convert.ToInt32(stockPrice) *2];

            for (int i = 0; i < Convert.ToInt32(stockPrice) * 2; i++)
            {
                d1 = (Math.Log(i / strike) + (0.03 + volatility * volatility / 2) * expirationTime) / (volatility * Math.Sqrt(expirationTime));
                delta = Black_Scholes.ND(d1);

                xs[i] = i;
                ys[i] = delta;
            }

            plt.AddScatter(xs, ys, label : " Delta ", color: System.Drawing.Color.Black);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);
            plt.SaveFig("Images/Delta.png");
        }
        public void CreateGammaGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            double d1;
            double gamma;

            var plt = new Plot();

            double[] xs = new double[Convert.ToInt32(stockPrice) * 2];
            double[] ys = new double[Convert.ToInt32(stockPrice) * 2];

            for (int i = 0; i < Convert.ToInt32(stockPrice) * 2; i++)
            {
                d1 = (Math.Log(i / strike) + (0.03 + volatility * volatility / 2) * expirationTime) / (volatility * Math.Sqrt(expirationTime));
                gamma = (1 / (stockPrice * Math.Sqrt(expirationTime) * volatility)) * (1 / Math.Sqrt(2 * Math.PI)) * Math.Exp(-Math.Pow(d1, 2) / 2);

                xs[i] = i;
                ys[i] = gamma;
            }

            plt.AddScatter(xs, ys, label: " Gamma ", color: System.Drawing.Color.Black);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);
            plt.SaveFig("Images/Gamma.png");
        }

        public void CreateThetaGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            double d1;
            double d2;
            double theta;
            double nD1Prime;

            var plt = new Plot();

            double[] xs = new double[Convert.ToInt32(stockPrice) * 2];
            double[] ys = new double[Convert.ToInt32(stockPrice) * 2];

            for (int i = 0; i < Convert.ToInt32(stockPrice) * 2; i++)
            {
                d1 = (Math.Log(i / strike) + (0.03 + volatility * volatility / 2) * expirationTime) / (volatility * Math.Sqrt(expirationTime));
                d2 = d1 - volatility * Math.Sqrt(expirationTime);
                nD1Prime = 1 / (stockPrice * volatility * Math.Sqrt(expirationTime)) * Math.Exp(-0.5 * d1 * d1);
                theta = -(stockPrice * nD1Prime * volatility) / (2 * Math.Sqrt(expirationTime)) - 0.03 * strike * Math.Exp(-0.03 * expirationTime) * Black_Scholes.ND(d2);

                xs[i] = i;
                ys[i] = theta;
            }

            plt.AddScatter(xs, ys, label: " Theta ", color: System.Drawing.Color.Black);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);
            plt.SaveFig("Images/Theta.png");
        }

        public void CreateVegaGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            double d1;
            double d2;
            double vega;
            double nD1Prime;

            var plt = new Plot();

            double[] xs = new double[Convert.ToInt32(stockPrice) * 2];
            double[] ys = new double[Convert.ToInt32(stockPrice) * 2];

            for (int i = 0; i < Convert.ToInt32(stockPrice) * 2; i++)
            {
                d1 = (Math.Log(i / strike) + (0.03 + volatility * volatility / 2) * expirationTime) / (volatility * Math.Sqrt(expirationTime));
                d2 = d1 - volatility * Math.Sqrt(expirationTime);
                nD1Prime = 1 / (stockPrice * volatility * Math.Sqrt(expirationTime)) * Math.Exp(-0.5 * d1 * d1);
                vega = stockPrice * nD1Prime * Math.Sqrt(expirationTime);

                xs[i] = i;
                ys[i] = vega;
            }

            plt.AddScatter(xs, ys, label: " Vega ", color: System.Drawing.Color.Black);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);
            plt.SaveFig("Images/Vega.png");
        }

        public void CreateRhoGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            double d1;
            double d2;
            double rho;

            var plt = new Plot();

            double[] xs = new double[Convert.ToInt32(stockPrice) * 2];
            double[] ys = new double[Convert.ToInt32(stockPrice) * 2];

            for (int i = 0; i < Convert.ToInt32(stockPrice) * 2; i++)
            {
                d1 = (Math.Log(i / strike) + (0.03 + volatility * volatility / 2) * expirationTime) / (volatility * Math.Sqrt(expirationTime));
                d2 = d1 - volatility * Math.Sqrt(expirationTime);
                rho = strike * expirationTime * Math.Exp(-0.03 * expirationTime) * Black_Scholes.ND(d2);

                xs[i] = i;
                ys[i] = rho;
            }

            plt.AddScatter(xs, ys, label: " Rho ", color: System.Drawing.Color.Black);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);
            plt.SaveFig("Images/Rho.png");
        }
    }
}