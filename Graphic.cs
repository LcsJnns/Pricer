using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Function;
using ScottPlot;

namespace Graphic
{
    public class Graphe
    {
        public void CreateGraphe()
        {
            var plt = new Plot();

            double[] xs = { 1, 2, 3, 4, 5 };
            double[] ys = { 1, 4, 9, 16, 25 };

            plt.PlotScatter(xs, ys);
            plt.SaveFig("Black_Scholes.png");
        }
    }
}