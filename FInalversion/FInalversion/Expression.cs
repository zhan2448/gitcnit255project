using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class Expression
    {
        // Data
        protected double Value;
        protected string[] InputNames;
        protected string[,] InputList;
        // Show Data
        protected string Title;
        protected string InputType;

        public Expression()
        {
            // Setting up default values
            Title = "not set";
            InputType = "not set";
        }

       // public void SetValue(double xValue) { Value = xValue; }

        public double GetValue() { return Value; }

        public string GetInputType() { return InputType; }

        public void CalculateValue() { }
    }
}
