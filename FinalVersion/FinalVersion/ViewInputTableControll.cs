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
            if(seletedexpression.GetAllTitle()=="T_Value"){
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
        partial void Btncal_TouchUpInside(UIButton sender)
        {
            Formula[] TestF = new Formula[1];
            TestF[0] = new Formula();
            //[0].SetTitle("Calculate P(X), X~Binomial");
            TestF[0].SetTitle(sele.GetAllTitle());
            TestF[0].SetDescription("Big numbers break the system.");

   
                TestF[0].SetAnswer(sele);
            //

                FormulaView VFormula = new FormulaView();
                // To-Do: change the index accordingly to which Formula was selected
                VFormula.SetFormula(TestF[0]);

                this.NavigationController.PushViewController(VFormula, true);

        }
       
        public void preparetable(){
            var FormulaTable = new FormulaTable(temp);
            FormulaTable.SelectExpression += (sender, e) =>
            {
                LbInput.Text = "Success";
                btncal.Hidden = false;
                Btnroot.Hidden = false;
                sele = FormulaTable.temp;
            };



            InPutTable.Source = FormulaTable;


        }
     
    }

}