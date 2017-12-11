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
        }
    }
}
