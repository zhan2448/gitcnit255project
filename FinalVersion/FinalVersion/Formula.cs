using System;
using System.Collections.Generic;

namespace FinalVersion
{
    public class Formula
    {
        // Data
        private ExpressionConnected Answer;
        private List<Expression> InPutExpression;
        private List<int> SegmentsSelected; // Dependent selected segments
        // Show Data
        private string Title;
        private string Description;

        public Formula()
        {
            SegmentsSelected = new List<int>();
        }
        public void SetInPutExpression(List<Expression> InPutExpression) { this.InPutExpression=InPutExpression; }
        public List<Expression> GetInPutExpression() { return InPutExpression; }
        public void SetTitle(string xTitle) { Title = xTitle; }

        public void SetDescription(string xDescription) { Description = xDescription; }

        public void SetAnswer(ExpressionConnected xAns)
        {
            Answer = xAns;
        }

        public void SetExpressions(int[] xSelectedSegments)
        {

            //Queue<Expression> AllExprs = new Queue<Expression>();
            //AllExprs.Enqueue(Answer);

            //int i = 0;
            //while (true)
            //{
            //    if (0 == AllExprs.Count)
            //    {
            //        break;
            //    }

            //    Expression iExpression = AllExprs.Dequeue();

            //    if (iExpression is ExpressionConnected)
            //    {
            //        foreach (Expression SubExpr in ((ExpressionConnected)iExpression).GetSubExressions())
            //        {
            //            AllExprs.Enqueue(SubExpr);
            //        }
            //    }


            //    SegmentsSelected.Add(xSelectedSegments[i]);
            //    // AllTitles.AddRange(TempExpr.GetTitles());
            //   // AllInputTypes.AddRange(TempExpr.GetInputTypes());
            //}
        }


        public string GetTitle() { return Title; }
        public string GetDescription() { return Description; }

        public ExpressionConnected GetAnswer()
        {
            return Answer;
        }

        //public object[] GetExpressions()
        //{
        //    return Expressions;
        //}
    }
}