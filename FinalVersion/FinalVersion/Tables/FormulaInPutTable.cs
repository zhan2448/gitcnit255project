using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace FinalVersion
{
    public class FormulaInPutTable : UITableViewSource
    {
        ExpressionConnected inputExpressions;
        List<Expression[]> StatExpressions=new List<Expression[]>();
        public Expression[] temp { get; private set; }
        public FormulaInPutTable() { }
        public EventHandler SelectExpression;
        public bool gettreat=false;
        public FormulaInPutTable(ExpressionConnected inputExpressions, List<Expression[]> Expressions)
        {
            this.inputExpressions = inputExpressions;
            StatExpressions = Expressions;
            if (StatExpressions == null)
            {
                sortStatExpressions();
            }
        }
        public void sortStatExpressions(){
            StatExpressions = inputExpressions.GetSubExressions();
            if(((ExpressionConnected)(inputExpressions.GetSubExressions()[0][0])).GetTreatLikePrimitive()==true){
                if (inputExpressions.GetTitle() == inputExpressions.GetSubExressions()[0][0].GetTitle())
                {
                    if (inputExpressions.GetSubExressions().Count < 2)
                    {
                        return;
                    }
                
                    gettreat = true;
  
                }
            }else return;


         
        }

    

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, "");
            if (inputExpressions.GetSegmentSelected() == -1)
            {
                if (gettreat == false)
                {
                    cell.TextLabel.Text = inputExpressions.GetSegmentsTitles()[indexPath.Row];
                }
                else if (gettreat == true)
                {
                    cell.TextLabel.Text = inputExpressions.GetSegmentsTitles()[indexPath.Row + 1];
                }
            }
            else cell.TextLabel.Text = StatExpressions[indexPath.Row][0].GetTitle();

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (inputExpressions.GetSegmentSelected() == -1)
            {
                if (gettreat == false)
                {
                    return inputExpressions.GetSegmentsTitles().Count;
                }
                else
                {
                    return inputExpressions.GetSegmentsTitles().Count - 1;
                }
            }
            else return StatExpressions.Count;
           
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {

            if (gettreat == false)
            {
                inputExpressions.SetSegmentSelected(indexPath.Row);
                SelectExpression?.Invoke(inputExpressions,null);

            }
            else
            {
                inputExpressions.SetSegmentSelected(indexPath.Row+1);
                SelectExpression?.Invoke(inputExpressions,null);
            }
           
        }

    }
}
