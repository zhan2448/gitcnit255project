using System;
namespace FinalVersion
{
    public class Binomial_RV : ExpressionConnected
    {
        // Binomial Randon Variable
        public Binomial_RV(bool isprimtive):base(isprimtive) 
        {
            Expression[] firstDimention = new Expression[3];

            firstDimention[0] = new Sample_Size(true);
            firstDimention[1] = new Probability(true);
            firstDimention[2] = new Specific_Number();

            SubExpressions = new Expression[1][] { firstDimention };
        }
    }
}