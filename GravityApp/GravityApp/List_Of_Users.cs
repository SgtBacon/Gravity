using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Org.Json;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Environment = System.Environment;

namespace GravityApp
{
    class List_Of_Users
    {
        public List<UserClass> CurrentUsers { get; set; }

        public List_Of_Users()
        {
            CurrentUsers = new List<UserClass>();
        }

        public List_Of_Users(List<UserClass> list)
        {
            CurrentUsers = list;
        }

        public void WriteUsers() //Function to write/overwrite current List of Users (NOT FUNCTIONAL)
        {
            try
            {
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                string filename = System.IO.Path.Combine(path, "UserList.xml");

                XmlSerializer serializer = new XmlSerializer(typeof(List<UserClass>));
                FileStream Writer = new FileStream(filename, FileMode.Create);
                serializer.Serialize(Writer, this.CurrentUsers);
                Writer.Close();
            }
            catch(Exception e)
            {
                Exception ie = e.InnerException;
            }


        }
        public List<UserClass> LoadUsers() //Function to read through the list of current Users (NOT FUNCTIONAL)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string filename = System.IO.Path.Combine(path, "UserList.xml");
            

            XmlSerializer serializer = new XmlSerializer(typeof(List<UserClass>));
            FileStream reader = new FileStream(filename, FileMode.Open);
            this.CurrentUsers = (List<UserClass>) serializer.Deserialize(reader);
            reader.Close();
            return this.CurrentUsers;
        }

        public void AddUser(UserClass newUser)
        {
            this.CurrentUsers.Add(newUser);
        }

        public bool CheckUserEmail(string Email)
        {

            foreach (var User in this.CurrentUsers)
            {
                if (User.CheckEmail(Email))
                {
                    return true;
                }
                return false;

            }

            return false;
        }

    }
}