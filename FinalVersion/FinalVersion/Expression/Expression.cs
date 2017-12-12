using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class Expression
    {
        // DATA STRUCTURE
        //Values
        protected object Value;

        // Display Data
        private string Title;
        private string Sign;
        private string InputType;
        //


        // CONSTRUCTORS
        //Calculatable
        public Expression(string xTitle, string xSign, string xInputType)
        {
            Title = xTitle;
            Sign = xSign;
            InputType = xInputType;
        }

        //Non-calculatable
        public Expression() {
        }
        //
     
        public void SetValue(object xValue) { Value = xValue; }

        public object GetValue() { return Value; }

        //public string GetAllTitle() { string temp = "";
        //    for (int a = 0; a < Titles.Count;a++){
        //        temp = temp + Titles[a]+"+";
        //    }
        //    temp = temp.Substring(0, temp.Length - 1);
        //    return temp;
        //}

        public string GetTitle() { return Title; }

        public string GetSign() { return Sign; }

        public string GetInputType() { return InputType; }
    }
}
