using System;
using CoreGraphics;
using UIKit;

namespace cnit255team
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
            // Perform any additional setup after loading the view, typically from a nib.

            var btn1 = UIButton.FromType(UIButtonType.System);
            btn1.Frame = new CGRect(20, 200, 280, 44);
            btn1.SetTitle("Click Me", UIControlState.Normal);
            View.AddSubview(btn1);

            btn1.TouchUpInside += (sender, e) => {
                ViewFormula VFormula = new ViewFormula();
                VFormula.PrepareInputArea(new string[] { }, 0, new string[2] { "Population Mean", "DataSet" }, new string[2] { "s", "s" });

                this.NavigationController.PushViewController(VFormula, true);
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
