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
      
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           
            View.BackgroundColor = UIColor.White;
          
            PreparePicker();
           
        }
        Expression SelectedExpression;

        private void PreparePicker()
        {
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


            var picker = new UIPickerView
            {
                Frame =new CGRect(10,10,350,
                        300),
            };
            var findValuePickerModel = new FindValuePickerModel(StatExpressions);
            findValuePickerModel.GetSelectedExpression += (sender, e) =>
            {

                SelectedExpression = findValuePickerModel.Ex1;
                PrepareInPUtPicker();

            };
            picker.Model = findValuePickerModel;

            picker.ShowSelectionIndicator = true;
            this.View.AddSubview(picker);
           
        }
        public UIPickerView picker2 = new UIPickerView
        {
            Frame = new CGRect(10, 250, 350,
                      300),
        };
        UIButton btn = new UIButton(UIButtonType.RoundedRect);
        public void PrepareInPUtPicker(){

            List<Expression> StatExpressions = new List<Expression>();
            List<Expression> FixStatExpressions = new List<Expression>();

            var b = SelectedExpression;

            if (b.GetType().IsSubclassOf(typeof(ExpressionConnected)))
            {
                ExpressionConnected temp = (FinalVersion.ExpressionConnected)b;
                var intArray = temp.GetSubExressions();
                for (int q = 0; q < intArray.Length;q++){

                    if(intArray[q].GetType().IsSubclassOf(typeof(ExpressionConnected))){
                        StatExpressions.Add(intArray[q]);

                    }else if(intArray[q].GetType().IsSubclassOf(typeof(Expression))){

                        FixStatExpressions.Add(intArray[q]);

                    }

                }
               
            }else b.GetValues();



            btn.SetTitle (FixStatExpressions[0].GetAllTitle(), UIControlState.Normal);             btn.Frame = new RectangleF (10, 400, 300, 300);             this.View.AddSubview (btn);  



            var findValuePickerModel = new FindValuePickerModel(StatExpressions);
           
            picker2.Model = findValuePickerModel;

            picker2.ShowSelectionIndicator = true;
          
            this.View.AddSubview(picker2);
          
        }


    }
}