using System;
namespace FinalVersion
{
    public class PopulationMean : Expression
    {
        public PopulationMean() : base("Population Mean", "μ", "s")
        {
        }

        public void CalculateValue(double xValue) { Value = (double)xValue; }
    }
}