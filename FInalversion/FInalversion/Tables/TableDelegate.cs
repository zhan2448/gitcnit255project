using System;
using System.Collections.Generic;
using UIKit;

namespace FinalVersion
{
    public class TableDelegate : UITableViewDelegate
    {
        private EventHandler Selectformula;
        private List<Formula> testF;

        public TableDelegate(List<Formula> testF)
        {
            this.testF = testF;
        }

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var action = UITableViewRowAction.Create(UITableViewRowActionStyle.Default, "Delete", (arg1, arg2) =>
            {
                var cell = tableView.CellAt(arg2);
                cell.TextLabel.Text += "_Clicked";
            });
            return new UITableViewRowAction[] { action };
        }
        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var selectedformula = testF[indexPath.Row];
           
            Selectformula?.Invoke(selectedformula, null);
        }
    }
}
