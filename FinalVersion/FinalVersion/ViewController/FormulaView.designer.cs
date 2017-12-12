// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FinalVersion
{
    [Register ("FormulaView")]
    partial class FormulaView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView caltable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (caltable != null) {
                caltable.Dispose ();
                caltable = null;
            }
        }
    }
}