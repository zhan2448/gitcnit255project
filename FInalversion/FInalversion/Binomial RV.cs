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
            // Values[2] – (int)x.
            Values = new object[3];

            Titles.Add("n");
            Titles.Add("p");
            Titles.Add("x");

            InputTypes.Add("s");
            InputTypes.Add("s");
            InputTypes.Add("s");
        }

        public Binomial_RV(int[] xIndex) : this(){
            for (int i = 0; i < xIndex.Length; i++)
            {
                Titles.RemoveAt(xIndex[i]);
            }
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