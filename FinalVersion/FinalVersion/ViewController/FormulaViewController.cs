using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace FinalVersion
{
    public partial class FormulaViewController : UIViewController
    {
        Formula input;
        public void setinput(Formula input) { this.input = input; }
        public FormulaViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var CalculationTable = new CalculationTable(input);
            caltable.Source = CalculationTable;
        }
    }
}