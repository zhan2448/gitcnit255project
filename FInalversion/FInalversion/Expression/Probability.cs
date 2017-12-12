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

            if (isPrimitive)
                return;

            Expression[] firstDimention = new Expression[1];
            firstDimention[0] = new Probability(true);

            Expression[] secondDimention = new Expression[1];
            secondDimention[0] = new T_Value(false);

            SubExpressions = new Expression[2][] {firstDimention, secondDimention};
        }
        public void SetP(double xP) { Value = (double)xP; }
        public double GetP() { return (double)Value; }

    }
}
