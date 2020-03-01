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

            SetContentView(Resource.Layout.SignUp);
            UserPicture = FindViewById<ImageButton>(Resource.Id.UserImage);
            UserPicture.Click += UserPicture_Click;
            CreateUser = FindViewById<Button>(Resource.Id.CreateNewUser);
            CreateUser.Click += CreateUser_Click;
        }

        private void CreateUser_Click(object sender, EventArgs e)
        {
            if (FindViewById<EditText>(Resource.Id.EnterName).Text.Length == 0 || FindViewById<EditText>(Resource.Id.EnterMajor).Text.Length == 0 || FindViewById<EditText>(Resource.Id.EnterEmail).Text.Length == 0)
            {
                AlertDialog.Builder dialog = new AlertDialog.Builder(this);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Woah there");
                alert.SetMessage("You're not done!");
                
                alert.Show();
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