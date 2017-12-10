﻿using System;
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
        public override nint NumberOfSections(UITableView tableView)
        {
            return 4;
        }
      
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
           
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
           
            if (indexPath.Section == 0)
            {
                cell.TextLabel.Text = StatExpressions.GetTitle();

                   
                cell.TextLabel.TextAlignment = UITextAlignment.Center;

            }else if (indexPath.Section == 1)
            {
                
                var cell2 = (Calculationcell)tableView.DequeueReusableCell("Cal_Cell", indexPath);

                string a = StatExpressions.GetInPutExpression()[0].GetTitles()[indexPath.Row];

                cell2.UpdateCell(a);

                return cell2;
            };
            return cell;
           


        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if(section==0){
                return 1;

            }
            if(section==2){

                return 1;
            }
            if(section==3){
                return 1;

            }
            else
            {
                int s = 0;
                for (int a = 0; a < StatExpressions.GetInPutExpression().Count; a++)
                {
                    for (int b = 0; b < StatExpressions.GetInPutExpression()[a].GetTitles().Count; b++)
                    {

                        s++;
                    }
                }
                return 3;
            }
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            
            SelectExpression?.Invoke(null, null);
        }




    }
}
