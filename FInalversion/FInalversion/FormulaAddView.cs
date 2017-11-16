using System;
using CoreGraphics;
using System.Reflection;
using System.Collections.Generic;
using UIKit;
using System.Linq;
using Foundation;

namespace FinalVersion
{
    public partial class FormulaAddView : UIViewController
    {
        public FormulaAddView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            PreparePicker();
        }

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




        }
    }
}