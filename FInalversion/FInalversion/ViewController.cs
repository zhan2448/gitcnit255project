using System;
using CoreGraphics;
using System.Reflection;
using System.Collections.Generic;
using UIKit;
using System.Linq;
using Foundation;

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

            //this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) =>  
            //{
            //}), true);

            // Reference: https://developer.xamarin.com/recipes/ios/content_controls/navigation_controller/add_a_nav_bar_bottom_toolbar/
            //var spacer = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace) { Width = 50 };
            //var btnLabel = new UIBarButtonItem("Add a Formula", UIBarButtonItemStyle.Plain, target: this, action: new ObjCRuntime.Selector(""));

            //this.SetToolbarItems(new UIBarButtonItem[] {
            //    spacer,
            //    new UIBarButtonItem(UIBarButtonSystemItem.Add, (s,e) => {  
            //        FormulaAddView AddFormula = new FormulaAddView();
                  
            //    // To-Do: change the index accordingly to which Formula was selected
                   
            //        this.NavigationController.PushViewController(AddFormula, true);
                
            //    }), btnLabel, spacer
            //}, true);

            //btnLabel.Clicked += (sender, e) =>
            //{
                
            //    FormulaAddView AddFormula = new FormulaAddView();
            //    // To-Do: change the index accordingly to which Formula was selected

            //    this.NavigationController.PushViewController(AddFormula, true);
            //};

            //this.NavigationController.ToolbarHidden = false;

            // Test Data
            //Formula[] TestF = new Formula[1];
            //TestF[0] = new Formula();
            //TestF[0].SetTitle("T Values from Values");
            //TestF[0].SetDescription("Calculate T_Value from primitive values.");

            //T_Value t = new T_Value();
            //TestF[0].SetAnswer(t);

            Formula[] TestF = new Formula[1];
            TestF[0] = new Formula();
            TestF[0].SetTitle("Calculate P(X), X~Binomial");
            TestF[0].SetDescription("Big numbers break the system.");

            pmf pmFunc = new pmf();
            TestF[0].SetAnswer(pmFunc);
            //

            var btn1 = UIButton.FromType(UIButtonType.System);
            btn1.Frame = new CGRect(20, 200, 280, 44);
            btn1.SetTitle(TestF[0].GetTitle(), UIControlState.Normal);
            View.AddSubview(btn1);

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
            // Setting up the navigation Bar style.
            // Reference: https://montemagno.com/ios-tip-change-status-bar-icon-text-colors/
            this.NavigationController.NavigationBar.TintColor = UIColor.White;
            NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
            this.NavigationController.NavigationBar.BarTintColor = UIColor.FromRGBA(66, 32, 168, 255);

            // iOS 11 style Nav. Bar.
            this.NavigationController.NavigationBar.PrefersLargeTitles = false;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
