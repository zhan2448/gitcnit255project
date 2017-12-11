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
        }
    }
}
