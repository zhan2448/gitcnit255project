using System;
namespace FinalVersion
{
    public class Sample_SD : ExpressionConnected
    {
        public Sample_SD(bool isprimtive):base(isprimtive) 
        {
            Title="Sample S.D.";
            Sign = "σ";
            InputType = "s";
            Expression[] firstSegment = new Expression[1];
            firstSegment[0] = new DataSet();
            SubExpressions = new Expression[1][] { firstSegment };
        }
    }
}
