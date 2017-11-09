using System;
namespace FinalVersion
{
    public class pmf : ExpressionComposed
    {
        // Probability Mass Function
        public pmf()
        {
            // Data
            // Values[0] – (int)x.
            Values = new object[1];

            Titles.Add("P(X = x)");
            InputTypes.Add("s");

            // Associated Data
            // SubExpressions[0] – Binomial_RV
            SubExpressions = new Expression[1];

            SubExpressions[0] = new Binomial_RV();
        }

        public void SetPX(int xX) { Values[0] = (int)xX; }

        public int GetPX() { return (int)Values[0]; }

        public void CalculateValues(Binomial_RV xB_rv) {
            double p = xB_rv.GetP();
            int n = xB_rv.GetN();
            int x = xB_rv.GetX();

            // Forumala: P(X = j) = nCj * p ^ j * q ^ (n - j),
            //        - nCr = n! / ((n-r)! * r!).
            Values[0] = (Factorial(n) / (Factorial(n - x) * Factorial(x))) * Math.Pow(p,x) * Math.Pow((1-p), (n-x));
        }

        // REDO into a separate class?
        private int Factorial(int n)
        {
           if (n >= 2) return n * Factorial(n - 1);
           return 1;
        }
    }
}