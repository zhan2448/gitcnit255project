using System;
namespace FinalVersion
{
    public class Formula
    {
        // Data
        private Expression Answer;
        private object[] Expressions;
        // Show Data
        private string Title;
        private string Description;

        public Formula()
        {
        }

        public void SetTitle(string xTitle) { Title = xTitle; }

        public void SetDescription(string xDescription) { Description = xDescription; }

        public void SetAnswer(Expression xAns)
        {
            Answer = xAns;
        }

        public void SetExpressions(object[] xExpressions) {
            Expressions = xExpressions;
        }


        public string GetTitle() { return Title; }
        public string GetDescription() { return Description; }

        public Expression GetAnswer()
        {
            return Answer;
        }

        public object[] GetExpressions() {
            return Expressions;
        }
    }
}
