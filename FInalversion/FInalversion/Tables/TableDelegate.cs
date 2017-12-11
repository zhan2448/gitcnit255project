using System;
using UIKit;

namespace FinalVersion
{
    public class TableDelegate : UITableViewDelegate
    {
        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var action = UITableViewRowAction.Create(UITableViewRowActionStyle.Default, "Delete", (arg1, arg2) =>
            {
                var cell = tableView.CellAt(arg2);
                cell.TextLabel.Text += "_Clicked";
            });
            return new UITableViewRowAction[] { action };
        }
    }
}
