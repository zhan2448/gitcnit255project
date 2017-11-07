using System;
namespace FinalVersion
{
    public class Formula
    {
        private object Answer;
        private object[] Expressions;

        public Formula()
        {
        }

        public void SetAnswer(object xAns)
        {
            Answer = xAns;
        }

        public object GetAnswer()
        {
            return Answer;
        }

        public void SetExpressions(object[] xExpressions) {
            Expressions = xExpressions;
        }

        public object[] GetExpressions() {
            return Expressions;
        }
    }
}
