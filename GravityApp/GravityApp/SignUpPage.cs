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
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Provider;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace GravityApp
{

    [Activity(Label = "SignUpPage")]
    public class SignUpPage : Activity
    {
        private ImageButton UserPicture;
        private Button CreateUser;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUp); //change current view on screen to SignUp page
            UserPicture = FindViewById<ImageButton>(Resource.Id.UserImage);
            UserPicture.Click += UserPicture_Click;
            CreateUser = FindViewById<Button>(Resource.Id.CreateNewUser);
            CreateUser.Click += CreateUser_Click;
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            string ErrorTitle = ""; //variables to augment for any error message/title that need to be added
            string ErrorMessage = "";
            AlertDialog.Builder dialog = new AlertDialog.Builder(this); //create an Alert message to alert the User of SignUp errors
            AlertDialog alert = dialog.Create();

            //Long If statement to check if any issues arise when the Continue button is clicked
            if (FindViewById<EditText>(Resource.Id.EnterName).Text.Length == 0 || FindViewById<EditText>(Resource.Id.EnterName).Text.Length >= 25 || FindViewById<EditText>(Resource.Id.EnterMajor).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterMajor).Text.Length >= 35 || FindViewById<EditText>(Resource.Id.EnterEmail).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterEmail).Text.Length >= 40)
            {
                //Smaller If statements to specifically check what issue arose (Name/Major/Email Character counts, Passwords matching, Email being used already, etc.
                if (FindViewById<EditText>(Resource.Id.EnterName).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterName).Text.Length >= 25)
                {
                    ErrorMessage = "You have to enter a Name and it must be below 25 characters";
                    ErrorTitle = "Error with Name";
                    alert.SetTitle(ErrorTitle);
                    alert.SetMessage(ErrorMessage);
                }
                else if (FindViewById<EditText>(Resource.Id.EnterMajor).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterMajor).Text.Length >= 35)
                {
                    ErrorMessage = "You have to enter a Major and it must be below 35 characters";
                    ErrorTitle = "Error with Major";
                    alert.SetTitle(ErrorTitle);
                    alert.SetMessage(ErrorMessage);
                }
                else if (FindViewById<EditText>(Resource.Id.EnterEmail).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterEmail).Text.Length >= 40)
                {
                    ErrorMessage = "You have to enter an Email and it must be below 40 characters";
                    ErrorTitle = "Error with Email";
                    alert.SetTitle(ErrorTitle);
                    alert.SetMessage(ErrorMessage);
                }


                alert.Show(); //Display error message to the screen
            }

            //CHECK IF EMAIL HAS BEEN USED BEFORE (read current list of Users and check their emails)
            //CHECK IF PASSWORDS MATCH (match their ID.Text attribute to each other)
            else
            {
                string UserName = FindViewById<EditText>(Resource.Id.EnterName).Text;
                string UserMajor = FindViewById<EditText>(Resource.Id.EnterMajor).Text;
                string UserEmail = FindViewById<EditText>(Resource.Id.EnterEmail).Text;
                string UserPassword = FindViewById<EditText>(Resource.Id.EnterPassword).Text;
                Drawable bitmap = (Drawable) FindViewById<ImageButton>(Resource.Id.UserImage).Background;
                UserClass NewUser = new UserClass(UserName, UserMajor, UserEmail, UserPassword , bitmap);

                // ADD USER TO LIST OF CURRENT USERS
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultcode, Intent data)
        {
            base.OnActivityResult(requestCode, resultcode, data);
            Bitmap bitmap = (Bitmap) data.Extras.Get("data");
            UserPicture.SetImageBitmap(bitmap);
        }
        private void UserPicture_Click(object sender, EventArgs e)
        {
            Intent CameraIntent = new Intent(MediaStore.ActionImageCapture); 
            StartActivityForResult(CameraIntent, 0);
        }
    }
}