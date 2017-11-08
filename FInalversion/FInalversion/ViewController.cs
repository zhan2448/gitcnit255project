using System;
using CoreGraphics;
using System.Collections.Generic;
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

            var btn1 = UIButton.FromType(UIButtonType.System);
            btn1.Frame = new CGRect(20, 200, 280, 44);
            btn1.SetTitle(TestF[0].GetTitle(), UIControlState.Normal);
            View.AddSubview(btn1);

            // TEST INSIDE TEST
            List<Expression> StatExpressions = new List<Expression>();
            StatExpressions.Add(new T_Value());
            StatExpressions.Add(new Sample());

            UIPickerView Pcker = new UIPickerView();
            Pcker.Frame = new CGRect(0, 250, View.Bounds.Width, 250);
            Pcker.ShowSelectionIndicator = true;
            Pcker.Hidden = false;

            Pcker.Model = new ExamplePickerViewModel(StatExpressions);;


            View.AddSubview(Pcker);
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

    public class ExamplePickerViewModel : UIPickerViewModel
    {
        private List<Expression> _myItems;
        protected int selectedIndex = 0;

        public ExamplePickerViewModel(List<Expression> items)
        {
            _myItems = items;
        }

        public Expression SelectedItem
        {
            get { return _myItems[selectedIndex]; }
        }

        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return _myItems.Count;
        }

        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return _myItems[(int)row].GetTitles()[0];
        }

        public override void Selected(UIPickerView picker, nint row, nint component)
        {
            selectedIndex = (int)row;
        }

        public override nfloat GetComponentWidth(UIPickerView picker, nint component)
        {
            if (component == 0)
                return 240f;
            else
                return 40f;
        }

        public override nfloat GetRowHeight(UIPickerView picker, nint component)
        {
            return 40f;
        }
    }
}
