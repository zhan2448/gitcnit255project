using System;
using CoreGraphics;
using UIKit;

namespace FinalVersion
{
    public partial class ViewController : UIViewController
    {
        // Test

        T_Value t = new T_Value();
        Formula[] TestF = new Formula[1] { };

        //

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.ViewDidAppear();

            var btn1 = UIButton.FromType(UIButtonType.System);
            btn1.Frame = new CGRect(20, 200, 280, 44);
            btn1.SetTitle("Click Me", UIControlState.Normal);
            View.AddSubview(btn1);

            btn1.TouchUpInside += (sender, e) => {
                FormulaView VFormula = new FormulaView();
                VFormula.PrepareInputArea(new string[] { }, 0, new string[2] { "Population Mean", "DataSet" }, new string[2] { "s", "s" });

                this.NavigationController.PushViewController(VFormula, true);
            };
        }

        private void ViewDidAppear()
        {
            // iOS 11 style Nav. Bar.
            this.NavigationController.NavigationBar.PrefersLargeTitles = true;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
