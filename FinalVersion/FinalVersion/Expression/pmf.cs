using System;
namespace FinalVersion
{
    public class pmf : ExpressionConnected
    {
        // Probability Mass Function
        public pmf(bool isPrimitive) : base(
            isPrimitive,
            typeof(pmf),
            "pmf",
            "P(X=x)",
            "s"
        )
        {
            if (isPrimitive)
                return;

            SegmentsTitles.Add("From Binomial");
            // Segments
            Expression[] secondSegment = new Expression[1];
            secondSegment[0] = new Binomial_RV();

            SubExpressions.Add(secondSegment);
        }

        public void CalculateValues(Binomial_RV xB_rv)
        {
            int n = (int)xB_rv.GetSubExressions()[0][0].GetValue();
            double p = (double)xB_rv.GetSubExressions()[0][1].GetValue();
            int x = (int)xB_rv.GetSubExressions()[0][2].GetValue();

            // Formula: P(X = j) = nCj * p ^ j * q ^ (n - j),
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