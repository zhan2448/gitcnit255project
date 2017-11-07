using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class Expression
    {
        protected double Value;
        protected string Title;
        protected string Type;
        protected string[] InputNames;
        protected string[,] InputList;

        public Expression()
        {
        }

        public void SetValue(double xValue) {
            Value = xValue;
        }

        public double GetValue() { return Value; }

        public void CalculateValue() { }
    }
}
