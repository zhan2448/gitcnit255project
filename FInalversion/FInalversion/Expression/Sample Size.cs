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
  

            Expression[] firstSegment = new Expression[1];
            firstSegment[0] = new DataSet();
            SubExpressions = new Expression[1][] { firstSegment };

        }
        public void SetN(int xN) { Value = (int)xN; }
        public int GetN() { return (int)Value; }
    }
}
