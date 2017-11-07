using System;
namespace FinalVersion
{
    public class PopulationMean : Expression
    {
        public PopulationMean()
        {
            Title = "Population Mean";
            Type = "s";
        }

        public void CalculateValue(double xValue) { Value = xValue; }
    }
}
