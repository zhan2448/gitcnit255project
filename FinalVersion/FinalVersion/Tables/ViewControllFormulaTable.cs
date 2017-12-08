using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace FinalVersion
{
    public class ViewControllFormulaTable : UITableViewSource
    {
        List<Formula> formula;
        public Formula temp { get; private set; }
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
            temp = selectedformula;
            Selectformula?.Invoke(null, null);
        }

    }
}
