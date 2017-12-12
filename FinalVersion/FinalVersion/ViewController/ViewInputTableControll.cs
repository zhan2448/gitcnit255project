using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;

namespace FinalVersion
{
    public partial class ViewInputTableControll : UIViewController
    {

        private List<Expression> StatExpressions = new List<Expression>();
        private List<Expression> FixStatExpressions = new List<Expression>();
        private List<object> tempExpression = new List<object>();
        private Expression[] returnExpression;

        public ExpressionConnected seletedexpression;
        // public List<Expression> temp = new List <Expression>();

        public ViewInputTableControll(IntPtr handle) : base(handle)
        {
        }

        partial void Btnroot_TouchUpInside(UIButton sender)
        {

            this.NavigationController.SetNavigationBarHidden(false, false);
            ViewController ViewController = this.Storyboard.InstantiateViewController("ViewController") as ViewController;
       //     ViewController.setPickedtexpression(returnExpression, seletedexpression);
            NavigationController.PushViewController(ViewController, true);

        }
        partial void Btncancel_TouchUpInside(UIButton sender)
        {
            this.NavigationController.SetNavigationBarHidden(false, false);
            NavigationController.PopViewController(true);


        }
        public override void ViewDidLoad()
        {
            this.NavigationController.SetNavigationBarHidden(true, false);
            base.ViewDidLoad();
            NavigationItem.Title = seletedexpression.GetTitle();

            preparetable();

            //if(seletedexpression.GetAllTitle()== "T_Values"){
            //    Sample sp = new Sample();
            //    sp.settempTitle("population mean");
            //    DataSet ds = new DataSet();
            //    ds.settempTitle("population mean");
            //    temp.Add(sp);
            //    temp.Add(ds);
            //}else if(seletedexpression.GetAllTitle() == "PMF Value"){
            //    Binomial_RV rv =  new Binomial_RV();
            //    temp.Add(rv);

            //}else if(seletedexpression.GetAllTitle()=="Sample Mean+Sample S.D.+Sample Size"){
            //    DataSet sd = new DataSet();
            //    temp.Add(sd);
            //}
            //SortExpression();

            //if (tempExpression.Count == 1)
            //{
            //    preparetable((List<Expression>)tempExpression[0], InPutTable,1);

            //}
            //else if (tempExpression.Count == 2)
            //{
            //    preparetable((List<Expression>)tempExpression[0], InPutTable, 2);
            //    LbInput2.Hidden = false;


            //}
        }
        public void LabelAndButton(List<Expression> e, int i)
        {
            if (i == e.Count)
            {
                LbInput.TextColor = UIColor.Green;
                LbInput.Text = "Success";
                Btnroot.Hidden = false;
            }
        }

        public void preparetable()
        {
            var FormulaInPutTable = new FormulaInPutTable(seletedexpression.GetSubExressions());
            FormulaInPutTable.SelectExpression += (sender, e) =>
            {
                returnExpression = FormulaInPutTable.temp;


            };
            InPutTable.Source = FormulaInPutTable;
        }


        //public void SortExpression()
        //{
        //var tempsub = seletedexpression.GetSubExressions();
        //foreach (Expression SubE in tempsub)
        //{
        //    List<Expression> x = new List<Expression>();
        //    if (SubE.GetType().IsSubclassOf(typeof(ExpressionConnected)))
        //    {
        //        ExpressionConnected EXC = (ExpressionConnected)SubE;
        //        x.Add(EXC);
        //        var tempsub2 = EXC.GetSubExressions();
        //        foreach (Expression SubE2 in tempsub2)
        //        {
        //            if (SubE2.GetType().IsSubclassOf(typeof(ExpressionConnected)))
        //            {
        //                ExpressionConnected EXC3 = (ExpressionConnected)SubE2;
        //                x.Add(EXC3);
        //                var tempsub3 = EXC3.GetSubExressions();
        //            }
        //            else if (SubE2.GetType().IsSubclassOf(typeof(ExpressionConnected)) == false)
        //            {
        //                Expression EX = (Expression)SubE2;
        //                x.Add(EX);
        //            }

        //        }

        //    }
        //    else if (SubE.GetType().IsSubclassOf(typeof(ExpressionConnected)) == false)
        //    {
        //        Expression EX1 = (Expression)SubE;
        //        x.Add(EX1);
        //    }
        //    tempExpression.Add(x);
        //}







        //for (int q = 0; q < tempsub.Length; q++)
        //{
        //    if (tempsub[q].GetType().IsSubclassOf(typeof(ExpressionConnected)))
        //    {
        //        ExpressionConnected temp2 = (ExpressionConnected)tempsub[q];



        //            if (temp2.GetSubExressions().Length == 1)
        //            {
        //                StatExpressions.Add(temp2);
        //                StatExpressions.Add(temp2.GetSubExressions()[0]);
        //            }
        //            else if (temp2.GetSubExressions().Length > 1)
        //            {
        //                for (int i = 0; i < temp2.GetSubExressions().Length; i++)
        //                {
        //                    if (temp2.GetSubExressions()[i].GetType().IsSubclassOf(typeof(ExpressionConnected)))
        //                    {
        //                        ExpressionConnected temp3 = (ExpressionConnected)temp2.GetSubExressions()[i];
        //                        if (temp3.GetSegments() == null)
        //                        {
        //                            StatExpressions.Add(temp3);
        //                        }
        //                        else if (temp2.GetSegments() != null)
        //                        {
        //                            if (temp3.GetSubExressions().Length == 1)
        //                            {
        //                                StatExpressions.Add(temp3);
        //                                StatExpressions.Add(temp3.GetSubExressions()[0]);
        //                            
        //                            else return;
        //                        }
        //                    }
        //                }

        //        }
        //    }
        //    else if (tempsub[q].GetType().IsSubclassOf(typeof(ExpressionConnected)) == false)
        //    {
        //        FixStatExpressions.Add(tempsub[q]);
        //    }
        //}

    }

}

