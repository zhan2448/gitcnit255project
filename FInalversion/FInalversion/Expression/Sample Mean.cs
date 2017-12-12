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
<<<<<<< HEAD
            if (isPrimitive)
                return;

            Expression[] secondSegment = new Expression[1];

            secondSegment[0] = new DataSet();

            SubExpressions.Add(secondSegment);
=======
            Title="Sample Mean";
            Sign = "x̅";
            InputType = "s";
            Expression[] firstSegment = new Expression[1];
            firstSegment[0] = new DataSet();
            SubExpressions = new Expression[1][] { firstSegment };

>>>>>>> 4005c016f7250a03ece18921b5c2900849737df7
        }
    }
}