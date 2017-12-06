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
       
       




        }

}