using System;
namespace FinalVersion
{
    public class pmf : ExpressionConnected
    {
        // Probability Mass Function
        public pmf(bool isprimtive):base(isprimtive) 
        {
            // Data
            // Values[0] – (int)x.
           
            Title="PMF Value";
            Sign="P(X = x)";
            InputType="s";

            // Associated Data
            // SubExpressions[0] – Binomial_RV
            //SubExpressions = new Expression[1];
            //SubExpressions[0] = new Binomial_RV();

            // Test: Hides one of the input fields.
            // SubExpressions[0] = new Binomial_RV(new int[] { 1 });
        }

    


        public void CalculateValues(Binomial_RV xB_rv)
        {
            int n = (int)xB_rv.GetSubExressions()[0][0].GetValue();
            double p   =(double)xB_rv.GetSubExressions()[0][1].GetValue();
            int x = (int)xB_rv.GetSubExressions()[0][2].GetValue();

            // Forumala: P(X = j) = nCj * p ^ j * q ^ (n - j),
            //        - nCr = n! / ((n-r)! * r!).
            Value = (Factorial(n) / (Factorial(n - x) * Factorial(x))) * Math.Pow(p, x) * Math.Pow((1 - p), (n - x));
        }

        // REDO into a separate class?
        private int Factorial(int n)
        {
            if (n >= 2) return n * Factorial(n - 1);
            return 1;
        }
    }
}