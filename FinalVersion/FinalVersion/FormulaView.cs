using Foundation;
using System;
using System.Reflection;
//using CustomCodeAttributes;
using CoreGraphics;
using UIKit;
using System.Collections.Generic;

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

            positionY = (int)NavigationController.NavigationBar.Frame.Bottom + positionX;
            PrepareHeading(OpenedFormula.GetTitle(), OpenedFormula.GetDescription());

            // Get a comprehensive list of expressions titles and inputTypes
            Queue<Expression> AllExprs = new Queue<Expression>();
            AllExprs.Enqueue(OpenedFormula.GetAnswer());

            List<string> AllTitles = new List<string>(), AllInputTypes = new List<string>();
            while (true)
            {
                if (0 == AllExprs.Count)
                {
                    break;
                }

                Expression TempExpr = AllExprs.Dequeue();
                if (TempExpr is ExpressionComposed)
                {
                    foreach (Expression SubExpr in ((ExpressionComposed)TempExpr).GetSubExressions())
                    {
                        AllExprs.Enqueue(SubExpr);
                    }
                }

                AllTitles.AddRange(TempExpr.GetTitles());
                AllInputTypes.AddRange(TempExpr.GetInputTypes());
            }

            // Preparing Expressions Area
            PrepareExpresionsArea(AllTitles.ToArray(), AllInputTypes.ToArray());

            // Creating Compute button
            var btnCompute = UIButton.FromType(UIButtonType.System);
            btnCompute.Frame = new CGRect(Graphs[0].Item2.Bounds.Right - positionX*2, positionY, 150, 45);
            btnCompute.SetTitle("Compute", UIControlState.Normal);
            btnCompute.SetTitleColor(UIColor.White, UIControlState.Normal);
            // btnCompute.Layer.BorderColor = UIColor.FromRGBA(142, 68, 173, 100).CGColor;
            btnCompute.BackgroundColor = UIColor.FromRGBA(142, 68, 173, 255);
            btnCompute.Layer.CornerRadius = 5f;

            View.AddSubview(btnCompute);

            //
            btnCompute.TouchUpInside += (sender, e) =>
            {
                for (int i = 0; i < Graphs.Length; i++)
                {
                    // if (OpenedFormula.)
                    //{

                    // }
                }
            };


            View.BackgroundColor = UIColor.White;
        }


        // Functional Methods:
        private void PrepareHeading(string title, string desc)
        {
            this.Title = title;

            UILabel lb = AddLabel(desc, "description");
            lb.Frame = new CGRect(positionX, positionY, lb.Frame.Width, lb.Frame.Height);
            positionY = (int)lb.Frame.Bottom + positionX;
            View.AddSubview(lb);
        }

        private void PrepareExpresionsArea(string[] LabelsNames, string[] InputFormat)
        {
            //UITableView table = new UITableView(View.Bounds); // defaults to Plain style
            //string[] tableItems = LabelsNames;
            //table.Source = (new UITableViewSource());
            //Add(table);

            Graphs = new Tuple<UILabel, UITextField>[LabelsNames.Length];


            for (int i = 0; i < LabelsNames.Length; i++)
            {
                Graphs[i] = AddGraph((LabelsNames[i] + ":"), InputFormat[i]);
                Graphs[i].Item1.Frame = new CGRect(positionX, positionY, Graphs[i].Item1.Frame.Width, Graphs[i].Item1.Frame.Height);
                Graphs[i].Item2.Frame = new CGRect((positionX + Graphs[i].Item1.Frame.Right), positionY, Graphs[i].Item2.Frame.Width, Graphs[i].Item1.Frame.Height);
                positionY = (int)Graphs[i].Item2.Frame.Bottom + positionX;

                View.AddSubview(Graphs[i].Item1);
                View.AddSubview(Graphs[i].Item2);
            }
        }


        // To-Do: Write PrepareAnswerArea() method
        //

        public void SetFormula(Formula xFormula) { OpenedFormula = xFormula; }



        //  private string[,] FetchLabels(object[] xExpressions) {
        //      Expression test = (Expression)Attribute.GetCustomAttribute((MemberInfo)xExpressions[0], typeof(Expression));
        //  }

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

                frame.Size = new CGSize(100, elementsHeigh);
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

        private Tuple<UILabel, UITextField> AddGraph(string label, string type)
        {
            UILabel lb = AddLabel(label, "normal");

            if (type == "s")
            {
                var txtField = new UITextField();
                txtField.BorderStyle = UITextBorderStyle.RoundedRect;
                txtField.BackgroundColor = UIColor.White;

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