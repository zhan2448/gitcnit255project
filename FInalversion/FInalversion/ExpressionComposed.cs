using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class ExpressionComposed : Expression
    {
        // Data
        protected Expression[] SubExpressions;

        public ExpressionComposed() : base() {
        }

        public Expression[] GetSubExressions()
        {
            return SubExpressions;
        }
    }
}
