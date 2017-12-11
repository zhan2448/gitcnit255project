using System;
using CoreGraphics;
using System.Reflection;
using System.Collections.Generic;
using UIKit;
using System.Linq;
using Foundation;
using Xamarin.Auth;
using Newtonsoft.Json;
namespace FinalVersion
{
    public partial class ViewController : UIViewController
    {

        private List<Expression> Pickedtexpression =new List<Expression>();
        private Expression answerexpression;
        Formula temp = new Formula();
        public void setPickedtexpression(List<Expression> Pickedtexpression, Expression answerexpression)
        {
            this.Pickedtexpression = Pickedtexpression;
            this.answerexpression = answerexpression;
        }
       
        partial void UIButton17067_TouchUpInside(UIButton sender)
        {
            var auth = new OAuth1Authenticator(

                consumerKey: "Iyn7ZJDVUpokTSPQDD6l2qkhq",
                consumerSecret: "0kc6KQrXzdjyfnjno2ubBct3exc8loYJs6wgwHkf46ntx74TE9",
                requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
                    authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
                    accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                callbackUrl: new Uri("http://www.website.com"));
        

            var ui = auth.GetUI();
            auth.Completed += TwitterAuth_Completed;
            PresentViewController(ui, true, null);
        }

        async void TwitterAuth_Completed(object sender, AuthenticatorCompletedEventArgs e){
            DismissViewController(true, null);

            if (e.IsAuthenticated){

                var request = new OAuth1Request("GET",
                               new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"),
                               null,
                               e.Account);

                var response = await request.GetResponseAsync();

                var json = response.GetResponseText();

                var twitterUser = JsonConvert.DeserializeObject<TwitterUser>(json);
                 DismissViewController(true, null);
                lb1.Text = "Hi: "+twitterUser.name;
                btnadd.Enabled = true;
            }
            DismissViewController(true, null);
        }

        partial void Test_TouchUpInside(UIButton sender)
        {
            FormulaViewController inputview = this.Storyboard.InstantiateViewController("FormulaViewController") as FormulaViewController;
            inputview.setinput(temp);
            this.NavigationController.PushViewController(inputview,true);
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.ViewDidAppear();
          //  btnadd.Enabled = false;




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

            //Test Data
            List<Formula> TestF = new List<Formula>();
            TestF.Add(new Formula());
            TestF[0] = new Formula();
            TestF[0].SetTitle("T Values from Values");
            TestF[0].SetDescription("Calculate T_Value from primitive values.");
             T_Value t = new T_Value();
            TestF[0].SetAnswer(t);
            Sample a = new Sample();
            PopulationMean b = new PopulationMean();

            Pickedtexpression.Add(a);
            Pickedtexpression.Add(b);
            TestF[0].SetInPutExpression(Pickedtexpression);

            TestF.Add(new Formula());
            TestF[1] = new Formula();
            TestF[1].SetTitle("Calculate P(X), X~Binomial");
            TestF[1].SetDescription("Big numbers break the system.");
            pmf pmFunc = new pmf();
            TestF[1].SetAnswer(pmFunc);
          
            //


            if (answerexpression != null)
            {
                TestF.Add(new Formula());
                TestF[2] = new Formula();
                TestF[2].SetTitle("Calculate P(X), X~Binomial");
                TestF[2].SetDescription("Big numbers break the system.");
                Expression temp2 = answerexpression;

                TestF[2].SetAnswer(temp2);
               
            }


            temp = TestF[0];
            var ViewControllFormulaTable = new ViewControllFormulaTable(TestF);
            ViewControllFormulaTable.Selectformula += (sender, e) =>
            {
                FormulaView VFormula = new FormulaView();
                // To-Do: change the index accordingly to which Formula was selected
                VFormula.SetFormula(ViewControllFormulaTable.temp);

                this.NavigationController.PushViewController(VFormula, true);
            };
            FormulaTable.Source = ViewControllFormulaTable;


            //var btn1 = UIButton.FromType(UIButtonType.System);

            //btn1.Frame = new CGRect(20, 200, 280, 44);
            //btn1.SetTitle(TestF[0].GetTitle(), UIControlState.Normal);
            //View.AddSubview(btn1);

            //btn1.TouchUpInside += (sender, e) =>
            //{
                
            //    FormulaView VFormula = new FormulaView();
            //    // To-Do: change the index accordingly to which Formula was selected
            //    VFormula.SetFormula(TestF[0]);

            //    this.NavigationController.PushViewController(VFormula, true);



            //};
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
