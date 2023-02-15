using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function;
using Map;
using ScottPlot;

namespace Graphic
{
    public class Graphe
    {
        public void CreateCallGraphe(double stockPrice, double strike, double expirationTime, double volatility)
        {
            var plt = new Plot();

            

            double callPrice = Black_Scholes.Call_Pricing(stockPrice, strike, expirationTime, 0.03, volatility);

            double[] xs = {  stockPrice/2,  strike ,  strike + callPrice,  strike + (2 * callPrice),  strike + (3 * callPrice) };
            double[] ys = { -callPrice, - callPrice, 0 , callPrice , 2* callPrice };


            plt.PlotHLine(0, color: System.Drawing.Color.Blue, lineWidth: 1);
            plt.PlotVLine( strike,label : $"At the money : { strike}", color: System.Drawing.Color.Red, lineWidth: 1);
            plt.PlotVLine( strike + callPrice,label : $"In the money : { strike + callPrice}" , color: System.Drawing.Color.Green, lineWidth: 1);
            plt.Legend(location: ScottPlot.Alignment.UpperLeft);

            plt.AddScatter(xs, ys, color : System.Drawing.Color.Black);
            plt.SaveFig("Black_Scholes_Call.png");
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
            plt.SaveFig("Black_Scholes_Put.png");
        }
    }
}