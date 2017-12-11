using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace FinalVersion
{
    public class ViewControllFormulaTable : UITableViewSource
    {
        List<Formula> formula;
       
        public ViewControllFormulaTable() { }

        public EventHandler Selectformula;

        public ViewControllFormulaTable(List<Formula> xFormula)
        {
            formula = xFormula;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            cell.TextLabel.Text = formula[indexPath.Row].GetTitle();
            cell.TextLabel.TextAlignment = UITextAlignment.Center;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return formula.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selectedformula = formula[indexPath.Row];
       
            Selectformula?.Invoke(selectedformula, null);
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
    }
}
