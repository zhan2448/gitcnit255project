using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class Expressions_Area_Table_Source : UITableViewSource
    {
        // DATA STRUCTURE
        //Composite Data
        private ExpressionConnected OpenedExpression;

        //Events
        public EventHandler Expression_Selected;
        //

        public Expressions_Area_Table_Source(ExpressionConnected xExpression) {
            OpenedExpression = xExpression;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 5;
        }


        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");

            if (indexPath.Section == 0)
            {
                //cell.TextLabel.Text = StatExpressions.GetTitle();


                cell.TextLabel.TextAlignment = UITextAlignment.Center;

            }else if (indexPath.Section == 2)
            {

                var cell2 = (Calculationcell)tableView.DequeueReusableCell("Cal_Cell", indexPath);

                //settitle();

                //cell2.UpdateCell(titles[indexPath.Row]);

                return cell2;
            }else if (indexPath.Section == 3){
                UIButton btn = new UIButton();


            }else if(indexPath.Section==1){

                UISegmentedControl expressionSeg = new UISegmentedControl();
                expressionSeg.RemoveAllSegments();
                //expressionSeg.InsertSegment(StatExpressions.GetAnswer().GetSegmentsTitles()[tmp],tmp,true);
                //tmp++;
            }
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
                //for (int a = 0; a < StatExpressions.GetInPutExpression().Count; a++)
                //{
                //    //for (int b = 0; b < StatExpressions.GetInPutExpression()[a].GetTitles().Count; b++)
                //    //{

                //    //    s++;
                //    //}
                //}
                return s;
            }
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Expression_Selected?.Invoke(null, null);
        }
    }
}
