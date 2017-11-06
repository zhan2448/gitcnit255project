using Foundation;
using System;
using CoreGraphics;
using UIKit;

namespace cnit255team
{
    public partial class ViewFormula : UIViewController
    {
        private int positionX = 20;
        private int positionY = 200;
        private Tuple<UILabel, UITextField>[] Graphs;

        public ViewFormula()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
        }

        public void ViewDidAppear() {
            this.NavigationController.NavigationBar.PrefersLargeTitles = false;
        }

        // Functional Methods:
        public void PrepareInputArea(string[] Segments, int segmentSelected, string[] LabelsNames, string[] InputFormat)
        {
            Graphs = new Tuple<UILabel, UITextField>[LabelsNames.Length];


            for (int i = 0; i < LabelsNames.Length; i++)
            {
                Graphs[i] = AddGraph((LabelsNames[i] + ":"), InputFormat[i]);
                Graphs[i].Item1.Frame = new CGRect(positionX, positionY, Graphs[i].Item1.Frame.Width, Graphs[i].Item1.Frame.Height);
                Graphs[i].Item2.Frame = new CGRect((positionX + Graphs[i].Item1.Frame.Right), positionY, Graphs[i].Item2.Frame.Width, Graphs[i].Item1.Frame.Height);
                positionY = (int)Graphs[i].Item2.Frame.Bottom + 10;

                View.AddSubview(Graphs[i].Item1);
                View.AddSubview(Graphs[i].Item2);
            }
        }





        // System Methods:
        private UILabel AddLabel(string label, string style)
        {
            UILabel lb = new UILabel();
            lb.TextAlignment = UITextAlignment.Left;
            lb.AdjustsFontSizeToFitWidth = true;
            lb.Text = label;

            //To-Do: different selection for different capitalisations.
            if (style == "normal")
            {
                // If different background, change:
                lb.TextColor = UIColor.Black;

                CGRect frame = lb.Frame;
                frame.Size = new CGSize(100, 30);
                lb.Frame = frame;
            }


            return lb;
        }

        private Tuple<UILabel, UITextField> AddGraph(string label, string type)
        {
            UILabel lb = AddLabel(label, "normal");

            if (type == "s")
            {
                var txtField = new UITextField();
                txtField.BorderStyle = UITextBorderStyle.None;
                txtField.BackgroundColor = UIColor.LightGray;

                CGRect frame = txtField.Frame;
                frame.Size = new CGSize(View.Bounds.Right - positionX * 3 - lb.Frame.Width, 30);
                txtField.Frame = frame;

                return Tuple.Create(lb, txtField);
            }

            return Tuple.Create(new UILabel(), new UITextField());
        }
    }
}