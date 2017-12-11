using Foundation;
using System;
using UIKit;

namespace FinalVersion
{
    public partial class Calculationcell : UITableViewCell
    {
   
        public Calculationcell (IntPtr handle) : base (handle)
        {
        }
      
      
       
        internal void UpdateCell(string a){
            lbtitle.Text = a;

        }


    }
}