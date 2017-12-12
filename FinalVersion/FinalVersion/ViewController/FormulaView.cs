using Foundation;
using System;
using System.Reflection;
//using CustomCodeAttributes;
using CoreGraphics;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace FinalVersion
{
    public partial class FormulaView : UIViewController
    {
        // Formula Data
        private Formula OpenedFormula;
        // UI
        private int positionX = 12;
        private int positionY;
        private nfloat elementsHeigh = 40f;
        private Tuple<UILabel, UITextField>[] Graphs;


        public FormulaView()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.NavigationController.ToolbarHidden = true;

            positionY = (int)NavigationController.NavigationBar.Frame.Bottom + positionX;
            PrepareHeading(OpenedFormula.GetTitle(), OpenedFormula.GetDescription());

            // Get a comprehensive list of expressions titles and inputTypes
            List<string> AllTitles = new List<string>(), AllInputTypes = new List<string>(), AllSigns = new List<string>();

            Queue<Expression> AllExprs = new Queue<Expression>();
            AllExprs.Enqueue(OpenedFormula.GetAnswer());
            //while (true)
            //{
            //    if (0 == AllExprs.Count)
            //    {
            //        break;
            //    }

            //    Expression TempExpr = AllExprs.Dequeue();
            //    if (TempExpr is ExpressionConnected)
            //    {
            //        foreach (Expression SubExpr in ((ExpressionConnected)TempExpr).GetSubExressions())
            //        {
            //            AllExprs.Enqueue(SubExpr);
            //        }
            //    }

            //    AllTitles.AddRange(TempExpr.GetTitles());
            //    AllSigns.AddRange(TempExpr.GetSigns());
            //    AllInputTypes.AddRange(TempExpr.GetInputTypes());
            //}

            // Preparing Expressions Area
            PrepareExpresionsArea(AllSigns.ToArray(), AllTitles.ToArray(), AllInputTypes.ToArray());

            // Creating Compute button
            // Real green: UIColor.FromRGBA(94, 191, 19, 255).
            var btnCompute = UIButton.FromType(UIButtonType.System);
            CGRect frame = btnCompute.Frame;
            frame.Size = new CGSize(150, elementsHeigh);
            frame.Location = new CGPoint(Graphs[0].Item2.Bounds.Right - frame.Width * 0.5, positionY);
            btnCompute.Frame = frame;
            btnCompute.SetTitle("Compute", UIControlState.Normal);
            btnCompute.SetTitleColor(UIColor.FromRGBA(66, 32, 168, 255), UIControlState.Normal);
            btnCompute.BackgroundColor = UIColor.FromRGBA(240, 240, 240, 255);
            btnCompute.Layer.CornerRadius = 5f;
            View.AddSubview(btnCompute);

            // TEST SEGMENT
            // Reference: https://developer.xamarin.com/recipes/ios/standard_controls/segmented_button_control/configure_segments_(uisegmentedcontrol)/
            //var segmentControl = new UISegmentedControl();
            //segmentControl.Frame = new CGRect(positionX, btnCompute.Frame.Bottom + positionX, Graphs[1].Item2.Frame.Right - positionX, 28);
            //segmentControl.InsertSegment("T Value", 0, false);
            //segmentControl.InsertSegment("Z Value", 1, false);
            //segmentControl.SelectedSegment = 0;
            //segmentControl.ValueChanged += (sender, e) => {
            //    var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;
            //    // do something with selectedSegmentId
            //};
            //View.AddSubview(segmentControl);
            //

            // TEST AREA (danger, it's hardcoded)
            object[] tempArray = new object[3];
            tempArray[0] = new int();
            tempArray[1] = new double();
            tempArray[2] = new int();

            btnCompute.TouchUpInside += (sender, e) =>
            {
                tempArray[0] = int.Parse(Graphs[1].Item2.Text);
                tempArray[1] = double.Parse(Graphs[2].Item2.Text);
                tempArray[2] = int.Parse(Graphs[3].Item2.Text);

         //       Binomial_RV brv = new Binomial_RV();
       //         brv.CalculateValues((int)tempArray[0], (double)tempArray[1], (int)tempArray[2]);

          //      OpenedFormula.GetAnswer().GetType().GetMethod("CalculateValues").Invoke(OpenedFormula.GetAnswer(), new object[] { brv });

                // Change it to the proper output area.
                Graphs[0].Item2.Text = OpenedFormula.GetAnswer().GetValue().ToString();
            };

            View.BackgroundColor = UIColor.White;
        }

        public void SetFormula(Formula xFormula) { OpenedFormula = xFormula; }


        // Functional Methods:
        private void PrepareHeading(string title, string desc)
        {
            this.Title = title;

            UILabel lb = AddLabel(desc, "description");
            lb.Frame = new CGRect(positionX, positionY, lb.Frame.Width, lb.Frame.Height);
            positionY = (int)lb.Frame.Bottom + positionX;
            View.AddSubview(lb);
        }

        private void PrepareExpresionsArea(string[] LabelsNames, string[] Placeholders, string[] InputFormat)
        {
            //UITableView table = new UITableView(View.Bounds); // defaults to Plain style
            //string[] tableItems = LabelsNames;
            //table.Source = (new UITableViewSource());
            //Add(table);

            Graphs = new Tuple<UILabel, UITextField>[LabelsNames.Length];


            for (int i = 0; i < LabelsNames.Length; i++)
            {
                Graphs[i] = AddGraph((LabelsNames[i] + ":"), Placeholders[i], InputFormat[i]);
                Graphs[i].Item1.Frame = new CGRect(positionX, positionY, Graphs[i].Item1.Frame.Width, Graphs[i].Item1.Frame.Height);
                Graphs[i].Item2.Frame = new CGRect((positionX + Graphs[i].Item1.Frame.Right), positionY, Graphs[i].Item2.Frame.Width, Graphs[i].Item1.Frame.Height);
                positionY = (int)Graphs[i].Item2.Frame.Bottom + positionX;

                View.AddSubview(Graphs[i].Item1);
                View.AddSubview(Graphs[i].Item2);
            }
        }

        // To-Do: Write PrepareAnswerArea() method
        //

        // UI Generating Methods
        private UILabel AddLabel(string label, string style)
        {
            UILabel lb = new UILabel();
            lb.TextAlignment = UITextAlignment.Left;
            lb.AdjustsFontSizeToFitWidth = true;
            lb.Text = label;
            CGRect frame = lb.Frame;


            //To-Do: different selection for different capitalisations.
            if (style == "normal")
            {
                // If different background, change:
                lb.TextColor = UIColor.Black;

                frame.Size = new CGSize(50, elementsHeigh);
                lb.Frame = frame;
            }
            else if (style == "description")
            {
                // If different background, change:
                lb.TextColor = UIColor.Gray;

                frame.Size = new CGSize(View.Bounds.Width, elementsHeigh);
                lb.Frame = frame;
            }

            return lb;
        }

        private Tuple<UILabel, UITextField> AddGraph(string label, string placeholder, string type)
        {
            UILabel lb = AddLabel(label, "normal");

            if (type == "s")
            {
                var txtField = new UITextField();
                txtField.BorderStyle = UITextBorderStyle.RoundedRect;
                txtField.BackgroundColor = UIColor.White;
                txtField.Placeholder = placeholder;

                CGRect frame = txtField.Frame;
                frame.Size = new CGSize(View.Bounds.Right - positionX * 3 - lb.Frame.Width, elementsHeigh);
                txtField.Frame = frame;

                return Tuple.Create(lb, txtField);
            }
            else if (type == "m") 
            {
                // To-Do: create a textView.
            }

            return Tuple.Create(new UILabel(), new UITextField());
        }
    }
}