using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class CalculationTable : UITableViewSource
    {
        Formula StatExpressions;
        public Expression temp { get; private set; }
        public CalculationTable() { }
        public EventHandler SelectExpression;
        public CalculationTable(Formula xStatExpressions)
        {
            StatExpressions = xStatExpressions;
        }
       
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            cell.TextLabel.Text = StatExpressions.GetTitle();
            cell.TextLabel.Text = StatExpressions.GetInPutExpression()[indexPath.Section].GetTitles()[indexPath.Row];

            cell.TextLabel.TextAlignment = UITextAlignment.Left;

          








            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            int s = 0;
            for (int a = 0; a < StatExpressions.GetInPutExpression().Count;a++){
                for (int b = 0; b < StatExpressions.GetInPutExpression()[a].GetTitles().Count;b++){

                    s++;
                }
            }
            return s;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            
            SelectExpression?.Invoke(null, null);
        }




    }
}
