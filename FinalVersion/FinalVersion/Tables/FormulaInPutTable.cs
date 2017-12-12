using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class FormulaInPutTable : UITableViewSource
    {
        ExpressionConnected inputExpressions;
        List<Expression[]> StatExpressions;
        public Expression[] temp { get; private set; }
        public FormulaInPutTable() { }
        public EventHandler SelectExpression;

        public FormulaInPutTable(ExpressionConnected inputExpressions)
        {
            this.inputExpressions = inputExpressions;
            sortStatExpressions();
        }
        public void sortStatExpressions(){
            //if(inputExpressions.GetTreatLinkPrimitive()==false){



            //    if (inputExpressions.GetTitle() == inputExpressions.GetSubExressions()[0][0].GetTitle())
            //    {
            //        if (inputExpressions.GetSubExressions().Count < 2)
            //        {
            //            return;
            //        }
            //        int num = 0;
            //        StatExpressions = new Expression[inputExpressions.GetSubExressions().Count - 1][];
            //        for (int a = 1; a < inputExpressions.GetSubExressions().Count; a++)
            //        {
            //            Expression[] newexpression = new Expression[inputExpressions.GetSubExressions()[a].Length];
            //            for (int b = 0; b < inputExpressions.GetSubExressions()[a].Length; b++)
            //            {
            //                newexpression[b] = inputExpressions.GetSubExressions()[a][b];
            //            }
            //            StatExpressions[num] = newexpression;
            //            num++;
            //        }
            //    }else 
            //}else return;


           // StatExpressions = inputExpressions.GetSubExressions();
        }

    

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");

            cell.TextLabel.Text = inputExpressions.GetSegmentsTitles()[indexPath.Row];
               

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return inputExpressions.GetSegmentsTitles().Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            inputExpressions.SetSegmentSelected(indexPath.Row);
            SelectExpression?.Invoke(inputExpressions, null);
        }

    }
}
