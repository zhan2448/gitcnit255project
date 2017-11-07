using System;
namespace FinalVersion
{
    public class PopulationMean : Expression
    {
        // Data
        // Values[0] – (double)Population Mean.

        public PopulationMean()
        {
            Titles.Add("Population Mean");
            InputTypes.Add("s");
        }

        public void CalculateValue(double xValue) { Values[0] = (double)xValue; }
    }
}
