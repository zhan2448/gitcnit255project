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
        private Formula PickedFormula;

        private void setPickedtexpression(Formula xPickedFormula)
        {
            PickedFormula = xPickedFormula;
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
            }
            DismissViewController(true, null);
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.ViewDidAppear();

            this.NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) =>  
            {
                FormulaAddView Addformulaview = this.Storyboard.InstantiateViewController("FormulaAddView") as FormulaAddView;
                this.NavigationController.PushViewController(Addformulaview, true);
            }), true);

            var ViewControllFormulaTable = new Formulas_Source(LoadFormulas());
           
            ViewControllFormulaTable.Formula_Selected += (sender, e) =>
            {
                FormulaView VFormula = this.Storyboard.InstantiateViewController("FormulaView") as  FormulaView;
                // To-Do: change the index accordingly to which Formula was selected
                VFormula.SetFormula((Formula)sender);
                this.NavigationController.PushViewController(VFormula, true);
            };

            FormulaTable.Source = ViewControllFormulaTable;
        }
       
        private List<Formula> LoadFormulas(){
            List<Formula> xFormulas = new List<Formula>();
            xFormulas.Add(new Formula());
            xFormulas[0].SetTitle("pmf from binomial RV");
            xFormulas[0].SetDescription("test");

            pmf xPMF = new pmf(false);
            xPMF.SetSegmentSelected(1);
            xFormulas[0].SetAnswer(xPMF);

            xFormulas.Add(new Formula());
            xFormulas[1].SetTitle("P value from T");
            xFormulas[1].SetDescription("find Pval");

            Probability xPval = new Probability(false);

            xPval.SetSegmentSelected(1);
            ((T_Value)xPval.GetSubExressions()[1][0]).SetSegmentSelected(1);
            xFormulas[1].SetAnswer(xPval);

            return xFormulas;
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
