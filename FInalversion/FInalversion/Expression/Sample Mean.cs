using System;
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
    }
}