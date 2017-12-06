﻿using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class FormulaTable : UITableViewSource
    {
        List<Expression> StatExpressions;
        public FormulaTable() { }
        public FormulaTable(List<Expression> xStatExpressions)
        {
            StatExpressions = xStatExpressions;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            cell.TextLabel.Text = StatExpressions[indexPath.Row].GetAllTitle();
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return StatExpressions.Count;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var selectedexpression = StatExpressions[indexPath.Row];
        }
       
    }
}