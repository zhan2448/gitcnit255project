using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class ExpressionConnected : Expression
    {
        // DATA STRUCTURE
        //Primitives
        private int SegmentSelected = 0;
        private bool enabledSubexpressions = false;

        //Composite Data
        protected string[] SegmentsTitles;
        protected Expression[][] SubExpressions;
        //

        //
        public ExpressionConnected(bool IsPrimitive = false)
        {
            enabledSubexpressions = IsPrimitive;
        }
        //

        public Expression[][] GetSubExressions()
        {
            return SubExpressions;
        }

        public void SetSegmentSelected(int xSS) { SegmentSelected = xSS; }

        public int GetSegmentSelected() { return SegmentSelected; }
        public bool GetDisableSubexpressions() { return enabledSubexpressions; }
        public string[] GetSegmentsTitles() { return SegmentsTitles; }
        public Expression[][] GetExpression() { return SubExpressions; }
    }
}