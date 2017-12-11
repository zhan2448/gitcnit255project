using System;
namespace FinalVersion
{
    public class PopulationMean : Expression
    {
        public PopulationMean()
        {
            // Data
            // Values[0] – (double)Population Mean.
            Values = new object[1];

            Title="Population Mean";
            InputType="s";
        }

        public void CalculateValues(double xValue) { Values[0] = (double)xValue; }
    }
}
