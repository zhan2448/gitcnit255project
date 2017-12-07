using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using CoreGraphics;

namespace FinalVersion
{
    public partial class ViewInputTableControll : UIViewController
    {


        partial void Btnroot_TouchUpInside(UIButton sender)
        {
            NavigationController.PopToRootViewController(true);
        }

        partial void Btncancel_TouchUpInside(UIButton sender)
        {
           
            NavigationController.PopViewController(true);
            this.NavigationController.SetNavigationBarHidden(false, false);
        }

      

        public Expression seletedexpression;
        public List<Expression> temp = new List <Expression>();

        public ViewInputTableControll(IntPtr handle) : base(handle)
        {
        }
      
        public override void ViewDidLoad()
        {
            this.NavigationController.SetNavigationBarHidden(true, false);
            base.ViewDidLoad();
            NavigationItem.Title = seletedexpression.GetAllTitle();
            if(seletedexpression.GetAllTitle()== "T_Values"){
                Sample sp = new Sample();
                sp.settempTitle("population mean");
                DataSet ds = new DataSet();
                ds.settempTitle("population mean");
                temp.Add(sp);
                temp.Add(ds);
            }else if(seletedexpression.GetAllTitle() == "PMF Value"){
                Binomial_RV rv =  new Binomial_RV();
                temp.Add(rv);

            }else if(seletedexpression.GetAllTitle()=="Sample Mean+Sample S.D.+Sample Size"){
                DataSet sd = new DataSet();
                temp.Add(sd);
            }


            preparetable();
           

        }
        Expression sele;
       
        public void preparetable(){
            var FormulaTable = new FormulaTable(temp);
            FormulaTable.SelectExpression += (sender, e) =>
            {
                LbInput.Text = "Success";
              
                Btnroot.Hidden = false;
                sele = FormulaTable.temp;
            };

            InPutTable.Source = FormulaTable;


        }

        public void SortExpression()
        {



            List<Expression> StatExpressions = new List<Expression>();
            List<Expression> FixStatExpressions = new List<Expression>();

            var b = sele;
            if (b.GetType().IsSubclassOf(typeof(ExpressionConnected)))
            {
                ExpressionConnected temp = (FinalVersion.ExpressionConnected)b; var tempsub = temp.GetSubExressions();
                for (int q = 0; q < tempsub.Length; q++)
                {
                    if (tempsub[q].GetType().IsSubclassOf(typeof(ExpressionConnected)))
                    {
                        ExpressionConnected temp2 = (FinalVersion.ExpressionConnected)tempsub[q];
                        if (temp2.GetSegments() == null)
                        {
                            StatExpressions.Add(temp2);
                        }
                        else if (temp2.GetSegments() != null)
                        {
                            if (temp2.GetSubExressions().Length == 1)
                            {
                                StatExpressions.Add(temp2);
                                StatExpressions.Add(temp2.GetSubExressions()[0]);
                            }
                            else if (temp2.GetSubExressions().Length > 1)
                            {
                                for (int i = 0; i < temp2.GetSubExressions().Length; i++)
                                {
                                    if (temp2.GetSubExressions()[i].GetType().IsSubclassOf(typeof(ExpressionConnected)))
                                    {
                                        ExpressionConnected temp3 = (ExpressionConnected)temp2.GetSubExressions()[i];
                                        if (temp3.GetSegments() == null)
                                        {
                                            StatExpressions.Add(temp3);
                                        }
                                        else if (temp2.GetSegments() != null)
                                        {
                                            if (temp3.GetSubExressions().Length == 1)
                                            {
                                                StatExpressions.Add(temp3);
                                                StatExpressions.Add(temp3.GetSubExressions()[0]);
                                            }
                                            else return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (tempsub[q].GetType().IsSubclassOf(typeof(ExpressionConnected)) == false)
                    {
                        FixStatExpressions.Add(tempsub[q]);
                    }
                }

            }

        }}

}