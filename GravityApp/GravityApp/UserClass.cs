using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GravityApp
{
    class UserClass
    {
        private string Name; //A User has a Name, Major, Email, Password (expressed in Strings), and an Image (expressed in a Drawable)
        private string Major;
        private string Email;
        private string Password;
        private Drawable Image;

        //ADD USER BIO (String? How many characters?)

        public UserClass() { }

        public UserClass(string N, string M, string E, string P, Drawable I)
        {
            Name = N;
            Major = M;
            Email = E;
            Password = P;
            Image = I;
        }
    }
}