using System;
using System.Linq;

namespace FinalVersion
{
    public class Sample_SD : ExpressionConnected
    {
        public Sample_SD(bool isPrimitive) : base(
            isPrimitive,
            typeof(Sample_SD),
            "Sample S.D.",
            "σ",
            "s"
        )
        {
            if (isPrimitive)
                return;

            SegmentsTitles.Add("From DataSet");
            Expression[] secondSegment = new Expression[1];

            secondSegment[0] = new DataSet();

            SubExpressions.Add(secondSegment);
        }

        public void CalculateValue(double xSD) {
            Value = (double)xSD;
        }

        public void CalculateValue(double[] xDataSet)
        {
            // Declaring the intermediate values.
            double x_bar;
            double sumOfElements = 0;

            x_bar = xDataSet.Sum() / xDataSet.Length;

            // Finding the sum of elements.
            foreach (int dataElement in xDataSet)
            {
                sumOfElements += Math.Pow(((double)dataElement - x_bar), 2);
            }

            Value = Math.Sqrt(sumOfElements / (xDataSet.Length - 1));
        }
    }
}