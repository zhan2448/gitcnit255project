using System;
namespace FinalVersion
{
    public class PopulationMean : Expression
    {
        public PopulationMean() : base("Population Mean", "μ", "s")
        {
        }

        public void CalculateValues(double xValue) { Value = (double)xValue; }
    }
}