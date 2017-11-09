using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class ExpressionConnected : Expression
    {
        // Data
        protected Expression[] SubExpressions;
        protected int SegmentSelected;
        protected string[] Segments;

        public ExpressionConnected()
        {
            // Default value
            SegmentSelected = 0;
        }

        public Expression[] GetSubExressions()
        {
            return SubExpressions;
        }

        public void SetSegmentSelected(int xSS) { SegmentSelected = xSS; }
        public int GetSegmentSelected() { return SegmentSelected; }
        public void SetSegments(string[] xSegments) { Segments = xSegments; }
        public string[] GetSegments() { return Segments; }
    }
}
