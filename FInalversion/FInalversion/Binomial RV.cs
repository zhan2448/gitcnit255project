using System;
namespace FinalVersion
{
    public class Binomial_RV : Expression
    {
        // Binomial Randon Variable
        public Binomial_RV()
        {
            // Data
            // Values[0] – (int)n.
            // Values[1] – (double)p.
            Values = new object[2];

            Titles.Add("n");
            Titles.Add("p");

            InputTypes.Add("s");
            InputTypes.Add("s");
        }


        public void SetN(int xN) { Values[0] = (int)xN; }
        public void SetP(double xP) { Values[1] = (double)xP; }
        public int GetN() { return (int)Values[0]; }
        public double GetP() { return (double)Values[1]; }
        public void CalculateValues(int xN, double xP) {
            SetN(xN);
            SetP(xP);
        }
    }
}