using System;
using CoreGraphics;
using System.Reflection;
using System.Collections.Generic;
using UIKit;
using System.Linq;
using Foundation;
using System.Drawing;

namespace FinalVersion
{
    public partial class FormulaAddView : UIViewController
    {
        protected FormulaAddView(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            PreparePicker();

        }
       

        private void PreparePicker()
        {
            Expression SelectedExpression;
            // Dynamically get a list of objects which are of type ExpressionConnected
            // Reference: https://stackoverflow.com/questions/981330/instantiate-an-object-with-a-runtime-determined-type
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace.StartsWith("FinalVersion", StringComparison.Ordinal));

            List<Expression> StatExpressions = new List<Expression>();
            foreach (var t in types)
            {
                if (t.IsSubclassOf(typeof(ExpressionConnected)))
                {
                    ExpressionConnected obj = (ExpressionConnected)Activator.CreateInstance(t);
                    StatExpressions.Add(obj);

                }
            }

            var FormulaTable = new FormulaTable(StatExpressions);
            FormulaTable.SelectExpression += (sender, e) =>
            {
                SelectedExpression = FormulaTable.temp;
              //  PrepareInPutPicker(SelectedExpression);
                ViewInputTableControll inputview = this.Storyboard.InstantiateViewController("ViewInputTableControll") as ViewInputTableControll;
                inputview.seletedexpression = SelectedExpression;
                this.NavigationController.PushViewController(inputview,true);
            };
            ViewFormulaTable.Source = FormulaTable;
            //var picker = new UIPickerView
            //{
            //    Frame = new CGRect(10, 10, 350,
            //            300),
            //};
            ////var findValuePickerModel = new FindValuePickerModel(StatExpressions);
            //findValuePickerModel.GetSelectedExpression += (sender, e) =>
            //{

            //    SelectedExpression = findValuePickerModel.Ex1;
            //    PrepareInPutPicker();

            //};
            //picker.Model = findValuePickerModel;

            //picker.ShowSelectionIndicator = true;
            //this.View.AddSubview(picker);

        }
       
        public UIPickerView picker2 = new UIPickerView
        {
            Frame = new CGRect(10, 250, 350,
                      300),
        };
        UIButton btn = new UIButton(UIButtonType.RoundedRect);



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
                btn.SetTitle(FixStatExpressions[0].GetAllTitle(), UIControlState.Normal);
                btn.Frame = new RectangleF(10, 400, 300, 300);
                this.View.AddSubview(btn);
                var findValuePickerModel = new FindValuePickerModel(StatExpressions);
                picker2.Model = findValuePickerModel;
                picker2.ShowSelectionIndicator = true;
                this.View.AddSubview(picker2);

            }


        }
    }
}