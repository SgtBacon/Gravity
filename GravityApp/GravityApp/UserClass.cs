using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
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

    public class UserClass 
    { 
        public string Name { get; set; } //A User has a Name, Major, Email, Password (expressed in Strings), and an Image (expressed in a Drawable)
        public string Major { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        private Drawable Image { get; set; }

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

        public bool CheckEmail(string ThisEmail)
        {

            if (this.Email == ThisEmail)
            {
                return true;
            }

            return false;
        }
    }
}