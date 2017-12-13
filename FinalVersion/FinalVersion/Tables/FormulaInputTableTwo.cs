using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class FormulaInPutTableTwo : UITableViewSource
    {
        Expression[] inputExpressions;
        public EventHandler SelectExpression;

        public FormulaInPutTableTwo(Expression[] inputExpressions)
        {
            this.inputExpressions = inputExpressions;
        }
        public void sortStatExpressions()
        {

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            cell.TextLabel.Text = inputExpressions[indexPath.Row].GetTitle();
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return inputExpressions.Length;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if ( inputExpressions[indexPath.Row].GetType().IsSubclassOf(typeof(ExpressionConnected))&&inputExpressions[indexPath.Row].GetSegmentSelected()==0)
            {
                tableView.Hidden = true;
                tableView.Source = new FormulaInPutTable((ExpressionConnected)inputExpressions[indexPath.Row]);
                tableView.ReloadData();
                tableView.Hidden = false;
            }
            else 
            {
                
                tableView.VisibleCells[indexPath.Row].Accessory = UITableViewCellAccessory.Checkmark;
                tableView.DeselectRow(indexPath,true);
     
            }
        }

    }
}

