using System;
namespace FinalVersion
{
    public class Sample_Size : ExpressionConnected
    {
        public Sample_Size(bool isprimtive):base(isprimtive) 
        {
            
            Title = "Sample Size";
            Sign = "n";
            InputType = "s";
        }
    }
}
