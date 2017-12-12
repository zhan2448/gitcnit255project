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

            SegmentsTitles.Add("From T_Value");

            Expression[] secondSegment = new Expression[1];
            secondSegment[0] = new T_Value(false);

            SubExpressions.Add(secondSegment);


        }
    }
}
