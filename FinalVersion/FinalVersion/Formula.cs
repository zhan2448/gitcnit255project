using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public class Formula
    {
        // Data
        private ExpressionConnected Answer;

        // Show Data
        private string Title;
        private string Description;

        public Formula()
        {
        }

        public void SetTitle(string xTitle) { Title = xTitle; }

        public void SetDescription(string xDescription) { Description = xDescription; }

        public void SetAnswer(ExpressionConnected xAns)
        {
            Answer = xAns;
        }

        public string GetTitle() { return Title; }
        public string GetDescription() { return Description; }

        public ExpressionConnected GetAnswer()
        {
            return Answer;
        }
    }
}