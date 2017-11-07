using System;
using CoreGraphics;
using UIKit;

namespace FinalVersion
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.ViewDidAppear();

            // Test Data
            Formula[] TestF = new Formula[1];
            TestF[0] = new Formula();
            TestF[0].SetTitle("T Values from Values");
            TestF[0].SetDescription("Calculate T_Value from primitive values.");

            T_Value t = new T_Value();
            TestF[0].SetAnswer(t);

            Sample S = new Sample(0);
            TestF[0].SetExpressions(new Sample[1] {S});


            var btn1 = UIButton.FromType(UIButtonType.System);
            btn1.Frame = new CGRect(20, 200, 280, 44);
            btn1.SetTitle(TestF[0].GetTitle(), UIControlState.Normal);
            View.AddSubview(btn1);

            //
            btn1.TouchUpInside += (sender, e) =>
            {
                FormulaView VFormula = new FormulaView();
                // To-Do: change the index accordingly to which Formula was selected
                VFormula.SetFormula(TestF[0]);

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
