using System;
namespace FinalVersion
{
    public class Binomial_RV : ExpressionConnected
    {
        // Binomial Randon Variable
        public Binomial_RV(bool isprimtive):base(isprimtive) 
        {
            Expression[] firstDimention = new Expression[3];

            firstDimention[0] = new Sample_Size(false);
            ((ExpressionConnected)firstDimention[0]);

            firstDimention[1] = new Probability(false);
            firstDimention[2] = new Specific_Number();

            SubExpressions = new Expression[1][] { firstDimention };
        }

        public void SetN(int xN) { Values[0] = (int)xN; }
        public void SetP(double xP) { Values[1] = (double)xP; }
        public void SetX(int xX) { Values[2] = (int)xX; }

        public int GetN() { return (int)Values[0]; }
        public double GetP() { return (double)Values[1]; }
        public int GetX() { return (int)Values[2]; }

        public void CalculateValues(int xN, double xP, int xX) {
            SetN(xN);
            SetP(xP);
            SetX(xX);
        }
    }
}