using System;
using System.Linq;

namespace FinalVersion
{
    public class Sample_Mean : ExpressionConnected
    {
        public Sample_Mean(bool isPrimitive) : base(
            isPrimitive,
            typeof(Sample_Mean),
            "Sample Mean",
            "x̅",
            "s"
        )
        {
            if (isPrimitive)
                return;

            Expression[] secondSegment = new Expression[1];

            secondSegment[0] = new DataSet();

            SubExpressions.Add(secondSegment);
        }


        // FUNCTIONAL METHODS
        public void CalculateValue(double xMean) {
            Value = (double)xMean;
        }


        public void CalculateValue(double[] xDataSet)
        {
            Value = (double)((double)xDataSet.Sum() / xDataSet.Length);
        }
        //
    }
}