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
        private Button LogInB;
        private List_Of_Users UserList = new List_Of_Users();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LogIn); //Change User view to LogIn page

            LogInB = FindViewById<Button>(Resource.Id.UserLogIn);
            LogInB.Click += LogInButton_OnClick;

            UserList.CurrentUsers = UserList.LoadUsers();

        }

        private void LogInButton_OnClick(object sender, EventArgs e)
        {
            string ErrorMessage = " ";
            string ErrorTitle = " ";

            AlertDialog.Builder dialog = new AlertDialog.Builder(this); //create an Alert message to alert the User of SignUp errors
            AlertDialog alert = dialog.Create();

            if (FindViewById<EditText>(Resource.Id.UserEmail).Text.Length <= 0 || 
                FindViewById<EditText>(Resource.Id.UserEmail).Text.Length >= 50 ||
                FindViewById<EditText>(Resource.Id.UserPassword).Text.Length <= 0 ||
                FindViewById<EditText>(Resource.Id.UserEmail).Text.Length >= 35)
            {
                if (FindViewById<EditText>(Resource.Id.UserEmail).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.UserEmail).Text.Length >= 50)
                {
                    ErrorMessage = "You have to enter your Email and it must be below 50 characters";
                    ErrorTitle = "Error with Email";
                    alert.SetTitle(ErrorTitle);
                    alert.SetMessage(ErrorMessage);
                }
                else if (FindViewById<EditText>(Resource.Id.UserPassword).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.UserPassword).Text.Length >= 35)
                {
                    ErrorMessage = "You have to enter your Password and it must be below 35 characters";
                    ErrorTitle = "Error with Password";
                    alert.SetTitle(ErrorTitle);
                    alert.SetMessage(ErrorMessage);
                }
            }
            else
            {
                if (UserList.CheckUserEmail(FindViewById<EditText>(Resource.Id.UserEmail).Text))
                {
                    ErrorTitle = "Error with Email";
                    ErrorMessage = "That Email is already in Use";
                    alert.SetMessage(ErrorMessage);
                    alert.SetTitle(ErrorTitle);
                    alert.Show();
                }
                else
                {

                }
            }
        }

        //LET USER ENTER THEIR EMAIL AND PASSWORD
        //CHECK IF EMAIL HAS BEEN USED
        //CHECK IF PASSWORD MATCHES GIVEN EMAIL
    }
}