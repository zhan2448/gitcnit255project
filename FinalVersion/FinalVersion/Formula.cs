using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public class Formula
    {
        // Data
        private Expression Answer;
        private List<int> SegmentsSelected; // Dependent selected segments
        // Show Data
        private string Title;
        private string Description;

        public Formula()
        {
            SegmentsSelected = new List<int>();
        }

        public void SetTitle(string xTitle) { Title = xTitle; }

        public void SetDescription(string xDescription) { Description = xDescription; }

        public void SetAnswer(Expression xAns)
        {
            Answer = xAns;
        }

        public void SetExpressions(int[] xSelectedSegments)
        {

            Queue<Expression> AllExprs = new Queue<Expression>();
            AllExprs.Enqueue(Answer);

            int i = 0;
            while (true)
            {
                if (0 == AllExprs.Count)
                {
                    break;
                }

                Expression iExpression = AllExprs.Dequeue();

                if (iExpression is ExpressionConnected)
                {
                    foreach (Expression SubExpr in ((ExpressionConnected)iExpression).GetSubExressions())
                    {
                        AllExprs.Enqueue(SubExpr);
                    }
                }


                SegmentsSelected.Add(xSelectedSegments[i]);
                // AllTitles.AddRange(TempExpr.GetTitles());
               // AllInputTypes.AddRange(TempExpr.GetInputTypes());
            }
        }


        public string GetTitle() { return Title; }
        public string GetDescription() { return Description; }

        public Expression GetAnswer()
        {
            return Answer;
        }

        //public object[] GetExpressions()
        //{
        //    return Expressions;
        //}
    }
}