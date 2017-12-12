using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class FormulaInPutTable : UITableViewSource
    {
        ExpressionConnected inputExpressions;
        Expression[][] StatExpressions;
        public Expression[] temp { get; private set; }
        public FormulaInPutTable() { }
        public EventHandler SelectExpression;

        public FormulaInPutTable(ExpressionConnected inputExpressions)
        {
            this.inputExpressions = inputExpressions;
            sortStatExpressions();
        }
        public void sortStatExpressions(){
            if(inputExpressions.GetDisabled()==false){



                if (inputExpressions.GetTitle() == inputExpressions.GetSubExressions()[0][0].GetTitle())
                {

                    if (inputExpressions.GetSubExressions().Length < 2)
                    {
                        return;
                    }
                    int num = 0;
                    StatExpressions = new Expression[inputExpressions.GetSubExressions().Length - 1][];
                    for (int a = 1; a < inputExpressions.GetSubExressions().Length; a++)
                    {


                        Expression[] newexpression = new Expression[inputExpressions.GetSubExressions()[a].Length];
                        for (int b = 0; b < inputExpressions.GetSubExressions()[a].Length; b++)
                        {

                            newexpression[b] = inputExpressions.GetSubExressions()[a][b];
                        }
                        StatExpressions[num] = newexpression;
                        num++;
                    }
                }else StatExpressions = inputExpressions.GetSubExressions();
            }else return;
           


        }

    

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            for (int a = 0; a < StatExpressions[indexPath.Row].Length; a++)
            {
                
                cell.TextLabel.Text = StatExpressions[indexPath.Row][a].GetTitle();
               
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return StatExpressions.Length;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Expression[] selectedexpression = StatExpressions[indexPath.Row];
           
            SelectExpression?.Invoke(selectedexpression, null);
        }

    }
}
