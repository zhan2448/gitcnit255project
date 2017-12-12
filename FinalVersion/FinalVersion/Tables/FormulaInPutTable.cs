using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class FormulaInPutTable : UITableViewSource
    {
        Expression[][] StatExpressions;
        public Expression[] temp { get; private set; }
        public FormulaInPutTable() { }
        public EventHandler SelectExpression;
        public FormulaInPutTable(Expression[][] xStatExpressions)
        {
            StatExpressions = xStatExpressions;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            for (int a = 0; a < StatExpressions[indexPath.Row].Length; a++)
            {
                cell.TextLabel.Text = StatExpressions[indexPath.Row][a].GetTitle();
                cell.TextLabel.TextAlignment = UITextAlignment.Center;
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return StatExpressions.Length;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selectedexpression = StatExpressions[indexPath.Row];
            temp = selectedexpression;
            SelectExpression?.Invoke(null, null);
        }

    }
}
