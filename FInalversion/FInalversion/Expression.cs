using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class Expression
    {
        // Data
        protected object[] Values;
        // Show Data
        protected int SegmentSelected;
        protected List<string> Segments;
        protected List<string> Titles;
        protected List<string> InputTypes;

        public Expression()
        {
            Segments = new List<string>();
            Titles = new List<string>();
            InputTypes = new List<string>();
        }

        public Expression(int xSelectedSegment) : this()
        {
            SegmentSelected = xSelectedSegment;
        }

        public void SetValues(object[] xValues) { Values = xValues; }

        public object[] GetValues() { return Values; }

        public List<string> GetTitles() { return Titles; }

        public List<string> GetInputTypes() { return InputTypes; }

        public void CalculateValues() { }
    }
}
