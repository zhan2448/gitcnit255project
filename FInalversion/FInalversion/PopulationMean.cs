using System;
namespace FinalVersion
{
    public class PopulationMean : Expression
    {
        public PopulationMean()
        {
            Title = "Population Mean";
            InputType = "s";
        }

        public void CalculateValue(double xValue) { Value = xValue; }
    }
}
