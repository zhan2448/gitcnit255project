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
    [Register ("ViewInputTableControll")]
    partial class ViewInputTableControll
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Btncancel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton Btnroot { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView InPutTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LbInput { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LbInput2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchDisplayController searchDisplayController { get; set; }

        [Action ("Btncancel_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Btncancel_TouchUpInside (UIKit.UIButton sender);

        [Action ("Btnroot_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Btnroot_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Btncancel != null) {
                Btncancel.Dispose ();
                Btncancel = null;
            }

            if (Btnroot != null) {
                Btnroot.Dispose ();
                Btnroot = null;
            }

            if (InPutTable != null) {
                InPutTable.Dispose ();
                InPutTable = null;
            }

            if (LbInput != null) {
                LbInput.Dispose ();
                LbInput = null;
            }

            if (LbInput2 != null) {
                LbInput2.Dispose ();
                LbInput2 = null;
            }

            if (searchDisplayController != null) {
                searchDisplayController.Dispose ();
                searchDisplayController = null;
            }
        }
    }
}