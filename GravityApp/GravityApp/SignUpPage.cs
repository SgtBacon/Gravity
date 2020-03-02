using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Icu.Text;
using Android.Provider;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace GravityApp
{

    [Activity(Label = "SignUpPage")]
    public class SignUpPage : Activity
    {
        private ImageButton UserPicture;
        private Button CreateUser;
        private List_Of_Users UserList = new List_Of_Users();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SignUp); //change current view on screen to SignUp page
            UserPicture = FindViewById<ImageButton>(Resource.Id.UserImage);
            UserPicture.Click += UserPicture_Click;
            CreateUser = FindViewById<Button>(Resource.Id.CreateNewUser);
            CreateUser.Click += CreateUser_Click;

            UserList.CurrentUsers = UserList.LoadUsers();
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            string ErrorTitle = ""; //variables to augment for any error message/title that need to be added
            string ErrorMessage = "";

            AlertDialog.Builder dialog = new AlertDialog.Builder(this); //create an Alert message to alert the User of SignUp errors
            AlertDialog alert = dialog.Create();

            //Long If statement to check if any issues arise when the Continue button is clicked
            if (FindViewById<EditText>(Resource.Id.EnterName).Text.Length == 0 || FindViewById<EditText>(Resource.Id.EnterName).Text.Length >= 25 || //Name character count
                FindViewById<EditText>(Resource.Id.EnterMajor).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterMajor).Text.Length >= 35 || //Major character count
                FindViewById<EditText>(Resource.Id.EnterEmail).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterEmail).Text.Length >= 40 || //Email character count
                FindViewById<EditText>(Resource.Id.EnterPassword).Text != FindViewById<EditText>(Resource.Id.EnterPasswordSecondTime).Text  || //Matching Passwords
                FindViewById<EditText>(Resource.Id.EnterPassword).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterPasswordSecondTime).Text.Length <= 0 || //Passwords less than/equal to 0
                FindViewById<EditText>(Resource.Id.EnterPassword).Text.Length >= 20 || FindViewById<EditText>(Resource.Id.EnterPasswordSecondTime).Text.Length >= 20 //Passwords greater than/equal to 20
                )
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
                else if (FindViewById<EditText>(Resource.Id.EnterPassword).Text != FindViewById<EditText>(Resource.Id.EnterPasswordSecondTime).Text)
                {
                    ErrorMessage = "Your passwords have to match!";
                    ErrorTitle = "Error with Password";
                    alert.SetMessage(ErrorMessage);
                    alert.SetTitle(ErrorTitle);
                }
                else if (FindViewById<EditText>(Resource.Id.EnterPassword).Text.Length <= 0 || FindViewById<EditText>(Resource.Id.EnterPasswordSecondTime).Text.Length <= 0)
                {
                    ErrorMessage = "Your passwords can't be blank!";
                    ErrorTitle = "Error with Password";
                    alert.SetMessage(ErrorMessage);
                    alert.SetTitle(ErrorTitle);
                }
                else if (FindViewById<EditText>(Resource.Id.EnterPassword).Text.Length >= 20 || FindViewById<EditText>(Resource.Id.EnterPasswordSecondTime).Text.Length >= 20)
                {
                    ErrorMessage = "Your passwords can't be more than 20 characters!";
                    ErrorTitle = "Error with Password";
                    alert.SetMessage(ErrorMessage);
                    alert.SetTitle(ErrorTitle);
                }


                alert.Show(); //Display error message to the screen
            }

            else
            {
                string UserName = FindViewById<EditText>(Resource.Id.EnterName).Text;
                string UserMajor = FindViewById<EditText>(Resource.Id.EnterMajor).Text;
                string UserEmail = FindViewById<EditText>(Resource.Id.EnterEmail).Text;
                string UserPassword = FindViewById<EditText>(Resource.Id.EnterPassword).Text;
                Drawable bitmap = (Drawable) FindViewById<ImageButton>(Resource.Id.UserImage).Background;
                UserClass NewUser = new UserClass(UserName, UserMajor, UserEmail, UserPassword , bitmap);
                if (UserList.CheckUserEmail(NewUser.Email))
                {
                    ErrorTitle = "Error with Email";
                    ErrorMessage = "That Email is already in Use";
                    alert.SetMessage(ErrorMessage);
                    alert.SetTitle(ErrorTitle);
                    alert.Show();
                }
                else
                {
                    UserList.AddUser(NewUser);
                    UserList.WriteUsers();
                    var LogInAct = new Intent(this, typeof(LogInPage));
                    StartActivity(LogInAct);


                }





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