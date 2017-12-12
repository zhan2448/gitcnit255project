using System;
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

            Expression[] secondSegment = new Expression[1];

            secondSegment[0] = new DataSet();

            SubExpressions.Add(secondSegment);
        }
    }
}
