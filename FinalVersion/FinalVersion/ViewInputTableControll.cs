using Foundation;
using System;
using UIKit;

namespace FinalVersion
{
    public partial class ViewInputTableControll : UIViewController
    {
        public Expression seletedexpression;
        public ViewInputTableControll (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Testlb.Text = seletedexpression.GetAllTitle();
        }
        public UIPickerView picker2 = new UIPickerView
        {
            Frame = new CGRect(10, 250, 350,
                     300),
        };
       


        public void PrepareInPutPicker(Expression xseletedexpression)
        {

            List<Expression> StatExpressions = new List<Expression>();
            List<Expression> FixStatExpressions = new List<Expression>();

            var b = xseletedexpression;

            if (b.GetType().IsSubclassOf(typeof(ExpressionConnected)))
            {
                ExpressionConnected temp = (FinalVersion.ExpressionConnected)b;
                var tempsub = temp.GetSubExressions();
                for (int q = 0; q < tempsub.Length; q++)
                {

                    if (tempsub[q].GetType().IsSubclassOf(typeof(ExpressionConnected)))
                    {
                        ExpressionConnected temp2 = (FinalVersion.ExpressionConnected)tempsub[q];
                        if (temp2.GetSegments() == null)
                        {
                            StatExpressions.Add(temp2);
                        }
                        else if (temp2.GetSegments() != null)
                        {
                            if (temp2.GetSubExressions().Length == 1)
                            {
                                StatExpressions.Add(temp2);
                                StatExpressions.Add(temp2.GetSubExressions()[0]);
                            }
                            else if (temp2.GetSubExressions().Length > 1)
                            {
                                for (int i = 0; i < temp2.GetSubExressions().Length; i++)
                                {
                                    if (temp2.GetSubExressions()[i].GetType().IsSubclassOf(typeof(ExpressionConnected)))
                                    {
                                        ExpressionConnected temp3 = (ExpressionConnected)temp2.GetSubExressions()[i];
                                        if (temp3.GetSegments() == null)
                                        {
                                            StatExpressions.Add(temp3);
                                        }
                                        else if (temp2.GetSegments() != null)
                                        {
                                            if (temp3.GetSubExressions().Length == 1)
                                            {
                                                StatExpressions.Add(temp3);
                                                StatExpressions.Add(temp3.GetSubExressions()[0]);
                                            }
                                            else return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (tempsub[q].GetType().IsSubclassOf(typeof(ExpressionConnected)) == false)
                    {
                        FixStatExpressions.Add(tempsub[q]);
                    }
                }
                var findValuePickerModel = new FindValuePickerModel(StatExpressions);
                picker2.Model = findValuePickerModel;
                picker2.ShowSelectionIndicator = true;
                this.View.AddSubview(picker2);

            }
    }
}