using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace GravityApp
{
    [Activity(Label = "Gravity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button MainLogIn;
        private Button MainSignUp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            //Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            //SetSupportActionBar(toolbar);
            MainLogIn = FindViewById<Button>(Resource.Id.LogIn);
            MainLogIn.Click += LogInButton_Click;
            MainSignUp = FindViewById<Button>(Resource.Id.SignUp);
            MainSignUp.Click += SignUpButton_Click;

        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            var SignUpAct = new Intent(this, typeof(SignUpPage));
            StartActivity(SignUpAct);

        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            var LogInAct = new Intent(this, typeof(LogInPage));
            StartActivity(LogInAct);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}

