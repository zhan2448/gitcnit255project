using System;
namespace FinalVersion
{
    public class Binomial_RV : ExpressionConnected
    {
        // Binomial Randon Variable
        public Binomial_RV() : base()
        {
            Expression[] firstSegment = new Expression[3];

            firstSegment[0] = new Sample_Size(true);
            firstSegment[1] = new Probability(true);
            firstSegment[2] = new Specific_Number();

            SubExpressions.Add(firstSegment);
        }
    }
}