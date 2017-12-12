using System;
namespace FinalVersion
{
    public class PopulationMean : Expression
    {
        public PopulationMean()
        {
            // Data
            // Values[0] – (double)Population Mean.
            Title="Population Mean";
            InputType="s";
        }

        public void CalculateValues(double xValue) { Value = (double)xValue; }
    }
}
