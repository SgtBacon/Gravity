using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GravityApp
{
    [Activity(Label = "LogInPage")]
    public class LogInPage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LogIn); //Change User view to LogIn page
        }

        //LET USER ENTER THEIR EMAIL AND PASSWORD
        //CHECK IF EMAIL HAS BEEN USED
        //CHECK IF PASSWORD MATCHES GIVEN EMAIL
    }
}