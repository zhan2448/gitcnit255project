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
        public void SetN(int xN) { Value = (int)xN; }
        public int GetN() { return (int)Value; }
    }
}
