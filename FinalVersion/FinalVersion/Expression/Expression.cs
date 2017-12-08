﻿using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class Expression
    {
        // Data
        protected object[] Values;
        // Show Data
        protected List<string> Titles;
        protected List<string> Signs;
        protected List<string> InputTypes;
       
        public Expression()
        {
            Titles = new List<string>();
            Signs = new List<string>();
            InputTypes = new List<string>();
        }

        public Expression(int[] xIndex) : this(){
            for (int i = 0; i < xIndex.Length; i++)
            {
                Titles.RemoveAt(xIndex[i]);
            }
        }
     
        public void settempTitle (string a ){

            Titles.Add((a));
        }

        public void SetValues(object[] xValues) { Values = xValues; }

        public object[] GetValues() { return Values; }

        public string GetAllTitle() { string temp = "";
            for (int a = 0; a < Titles.Count;a++){
                temp = temp + Titles[a]+"+";
            }
            temp = temp.Substring(0, temp.Length - 1);
            return temp;
        }

        public List<string> GetTitles() { return Titles; }

        public List<string> GetSigns() { return Signs; }

        public List<string> GetInputTypes() { return InputTypes; }
    }
}