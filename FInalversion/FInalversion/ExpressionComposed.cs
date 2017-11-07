using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public abstract class ExpressionComposed : Expression
    {
        public ExpressionComposed() : base() {
            SubExpressions = new List<Expression>();
        }

        // Data
        protected List<Expression> SubExpressions;

        public List<Expression> GetSubExressions()
        {
            return SubExpressions;
        }
    }
}
