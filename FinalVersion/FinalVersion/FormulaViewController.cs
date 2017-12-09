using Foundation;
using System;
using UIKit;

using ObjCRuntime;
namespace FinalVersion
{
    public partial class FormulaViewController : UIViewController
    {

       
        public FormulaViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var a = new CalculationTableControl();
        }
       
       
    }
}