using System;
using System.Linq;



namespace Function
{
    class Black_Scholes
    {
        // S = Cours de l'action sous-jacente
        // E = Prix d'exercice
        // r = Taux sans risque
        // v = Volatilité de l'action sous-jacente
        // T = durée restante jusqu'à écheance du call (en année)

        // Calcul du Call avec d1 et d2
        public static double Call_Pricing(double S, double E, double T, double r, double v)
        {
            double d1 = (Math.Log(S / E) + (r + v * v / 2) * T) / (v * Math.Sqrt(T));
            double d2 = d1 - v * Math.Sqrt(T);
            return S * ND(d1) - E * Math.Exp(-r * T) * ND(d2);
        }

        // Calcul du Put avec d1 et d2
        public static double Put_Pricing(double S, double E, double T, double r, double v)
        {
            double d1 = (Math.Log(S / E) + (r + v * v / 2) * T) / (v * Math.Sqrt(T));
            double d2 = d1 - v * Math.Sqrt(T);

            return E * Math.Exp(-r * T) * ND(-d2) - S * ND(-d1);
        }

        // ND pour Normal distribution, Loi normale centrée réduite, qui correspond a phi dans la formule de Black Scholes
        // a1, a2 ,a3, a4 et a5 sont des constantes utilisées pour calculer la distribution normale
        public static double ND(double E)
        {
            double L = 0.0;
            double K = 0.0;
            double dND = 0.0;
            const double a1 = 0.31938153;
            const double a2 = -0.356563782;
            const double a3 = 1.781477937;
            const double a4 = -1.821255978;
            const double a5 = 1.330274429;
            L = Math.Abs(E);
            K = 1.0 / (1.0 + 0.2316419 * L);
            dND = 1.0 - 1.0 / Math.Sqrt(2 * Math.PI) * Math.Exp(-L * L / 2.0) * (a1 * K + a2 * K * K + a3 * Math.Pow(K, 3.0) + a4 * Math.Pow(K, 4.0) + a5 * Math.Pow(K, 5.0));

            if (E < 0)
            {
                return 1.0 - dND;
            }
            return dND;
        }
    }
}