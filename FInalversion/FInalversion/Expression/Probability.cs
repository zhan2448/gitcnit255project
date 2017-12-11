using System;
namespace FinalVersion
{
    public class Probability : ExpressionConnected
    {
        public Probability(bool isPrimitive) : base(isPrimitive)
        {
            Title = "Probability";
            Sign = "p";
            InputType = "s";

            Expression[] firstDimention = new Expression[1];
            firstDimention[0] = new Probability(false);

            Expression[] secondDimention = new Expression[1];
            secondDimention[0] = new T_Value(true);

            SubExpressions = new Expression[2][] {firstDimention, secondDimention};
        }
    }
}
