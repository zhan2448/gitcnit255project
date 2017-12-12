using System;
namespace FinalVersion
{
    public class Sample_Size : ExpressionConnected
    {
        public Sample_Size(bool isPrimitive): base(
            isPrimitive,
            typeof(Sample_Size),
            "Sample Size",
            "n",
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

        public void CalculateValue(int xSize) { Value = (int)xSize; }

        public void CalculateValue(double[] xDataSet) { Value = xDataSet.Length; }
    }
}