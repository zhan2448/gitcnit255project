using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class ExpressionConnected : Expression
    {
        // DATA STRUCTURE
        //Primitives
        private int SegmentSelected = 0;
        private bool disableSubexpressions = false;

        //Composite Data
        protected string[] SegmentsTitles;
        protected Expression[][] SubExpressions;
        //

        //
        public ExpressionConnected(bool IsPrimitive = false)
        {
            disableSubexpressions = IsPrimitive;
        }
        //

        public Expression[][] GetSubExressions()
        {
            return SubExpressions;
        }

        public void SetSegmentSelected(int xSS) { SegmentSelected = xSS; }

        public int GetSegmentSelected() { return SegmentSelected; }
        public bool GetDisableSubexpressions() { return disableSubexpressions; }
        public string[] GetSegmentsTitles() { return SegmentsTitles; }
        public Expression[][] GetExpression() { return SubExpressions; }
    }
}