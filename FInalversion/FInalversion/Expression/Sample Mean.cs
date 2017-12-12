using System;
namespace FinalVersion
{
    public class Sample_Mean : ExpressionConnected
    {
        public Sample_Mean(bool isprimtive):base(isprimtive) 
        {
            Title="Sample Mean";
            Sign = "x̅";
            InputType = "s";
            Expression[] firstSegment = new Expression[1];
            firstSegment[0] = new DataSet();
            SubExpressions = new Expression[1][] { firstSegment };

        }
    }
}
