using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class FormulaInPutTable : UITableViewSource
    {
        ExpressionConnected inputExpressionsfix;
        ExpressionConnected inputExpressions;
        public EventHandler SelectExpression;
        public bool primitive = false;
        public FormulaInPutTable(ExpressionConnected inputExpressions, ExpressionConnected temp)
        {
            inputExpressionsfix = inputExpressions;
            this.inputExpressions = inputExpressions;
            sortStatExpressions();
        }
        public FormulaInPutTable(ExpressionConnected inputExpressions)
        {
            inputExpressionsfix = inputExpressions;
            this.inputExpressions = inputExpressions;

        }
        public void sortStatExpressions()
        {

            primitive = true;

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            if (primitive)
            {
                cell.TextLabel.Text = inputExpressions.GetSegmentsTitles()[indexPath.Row + 1];
            }
            else if (primitive == false)
            {
                cell.TextLabel.Text = inputExpressions.GetSegmentsTitles()[indexPath.Row];
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (primitive)
            {
                return inputExpressions.GetSegmentsTitles().Count - 1;
            }
            else
            {
                return inputExpressions.GetSegmentsTitles().Count;
            }

        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            if (primitive == true)
            {
                if (inputExpressions.GetSubExressions()[indexPath.Row + 1].Length == 1)
                {

                    if (inputExpressions.GetSubExressions()[indexPath.Row + 1][0].GetType().IsSubclassOf(typeof(ExpressionConnected)))
                    {
                        tableView.Hidden = true;
                        tableView.Source = new FormulaInPutTable((ExpressionConnected)inputExpressions.GetSubExressions()[indexPath.Row + 1][0]);

                        tableView.ReloadData();
                        tableView.Hidden = false;
                        primitive = false;
                    }
                    else
                    {
                        tableView.VisibleCells[indexPath.Row].Accessory = UITableViewCellAccessory.Checkmark;
                    }
                }
                else if (inputExpressions.GetSubExressions()[indexPath.Row + 1].Length > 1)
                {
                    tableView.Hidden = true;
                    tableView.Source = new FormulaInPutTableTwo(inputExpressions.GetSubExressions()[indexPath.Row + 1]);
                    tableView.ReloadData();
                    tableView.Hidden = false;
                }
                else
                {
                        if (inputExpressions.GetSubExressions()[indexPath.Row].Length == 1)
                        {

                        if (inputExpressions.GetSubExressions()[indexPath.Row][0].GetType().IsSubclassOf(typeof(ExpressionConnected)))
                        {
                            tableView.Hidden = true;
                            tableView.Source = new FormulaInPutTable((ExpressionConnected)inputExpressions.GetSubExressions()[indexPath.Row][0]);
                            tableView.ReloadData();
                            tableView.Hidden = false;
                        }
                        else
                        {
                            tableView.VisibleCells[indexPath.Row].Accessory = UITableViewCellAccessory.Checkmark;
                            tableView.DeselectRow(indexPath,true);
                        }
                    }
                    else if (inputExpressions.GetSubExressions()[indexPath.Row].Length > 1)
                    {
                        tableView.Hidden = true;
                        tableView.Source = new FormulaInPutTableTwo(inputExpressions.GetSubExressions()[indexPath.Row]);
                        tableView.ReloadData();
                        tableView.Hidden = false;

                    }
                }
            }

        }
    }
}

