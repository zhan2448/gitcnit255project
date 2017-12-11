using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class Expression
    {
        // Data
        protected object[] Values;
        // Show Data
        protected string Title;
        protected string Sign;
        protected string InputType;
       
        public Expression()
        {
        }

        //public Expression(int[] xIndex) : this(){
        //    for (int i = 0; i < xIndex.Length; i++)
        //    {
        //        Titles.RemoveAt(xIndex[i]);
        //    }
        //}
     
        public void SetValues(object[] xValues) { Values = xValues; }

        public object[] GetValues() { return Values; }

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
