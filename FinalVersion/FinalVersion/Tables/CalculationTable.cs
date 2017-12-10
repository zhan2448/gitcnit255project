using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class CalculationTable : UITableViewSource
    {
        List<Expression> StatExpressions;
        public Expression temp { get; private set; }
        public CalculationTable() { }
        public EventHandler SelectExpression;
        public CalculationTable(List<Expression> xStatExpressions)
        {
            StatExpressions = xStatExpressions;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            cell.TextLabel.Text = StatExpressions[indexPath.Row].GetAllTitle();
            cell.TextLabel.TextAlignment = UITextAlignment.Center;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return StatExpressions.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selectedexpression = StatExpressions[indexPath.Row];
            temp = selectedexpression;
            SelectExpression?.Invoke(null, null);
        }

    }
}
