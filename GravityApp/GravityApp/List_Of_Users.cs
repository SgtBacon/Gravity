using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Org.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Org.Json;
using Environment = System.Environment;

namespace GravityApp
{
    class List_Of_Users
    {
        private List<UserClass> CurrentUsers = new List<UserClass>();

        private void WriteUsers() //Function to write/overwrite current List of Users (NOT FUNCTIONAL)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            string filename = System.IO.Path.Combine(path, "UserList.txt");
            using (var file = File.Open(filename, FileMode.Create, FileAccess.Write))
            {
                using (var strm = new StreamWriter(file))
                {
                    strm.WriteLine();
                }
            }
        }
        private void LoadUsers() //Function to read through the list of current Users (NOT FUNCTIONAL)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            string filename = System.IO.Path.Combine(path, "UserList.txt");

            using (var streamreader = new StreamReader(filename))
            {
                string User = streamreader.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(User);
            }
        }
    }
}