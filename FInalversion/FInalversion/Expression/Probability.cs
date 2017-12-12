using System;
namespace FinalVersion
{
    public class Probability : ExpressionConnected
    {
        public Probability(bool isPrimitive) : base(
            isPrimitive,
            typeof(Probability),
            "Probability",
            "p",
            "s"
        )
        {
            if (isPrimitive)
                return;

            SegmentsTitles.Add("From Sample");
            SegmentsTitles.Add("From DataSet");

            Expression[] secondSegment = new Expression[1];
            secondSegment[0] = new Probability(true);

            Expression[] thirdSegment = new Expression[1];
            thirdSegment[0] = new T_Value(true);

            SubExpressions.Add(secondSegment);
            SubExpressions.Add(thirdSegment);
        }
    }
}
