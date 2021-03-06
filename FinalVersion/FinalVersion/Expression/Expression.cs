﻿using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class Expression: ICalculatable
    {
        // DATA STRUCTURE
        //Values
        protected object Value;
        protected int SegmentSelected = 0;

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
         

        // GETs & SETs
        public object GetValue() { return Value; }

        public int GetSegmentSelected() { return SegmentSelected; }
        public void SetSegmentSelected(int SegmentSelected ) { this.SegmentSelected= SegmentSelected; }


        public string GetTitle() { return Title; }

        public string GetSign() { return Sign; }

        public string GetInputType() { return InputType; }
        //
    }
}
