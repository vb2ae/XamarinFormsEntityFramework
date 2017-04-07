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
using System.IO;
using App13;
using App13.Droid;

[assembly: Xamarin.Forms.Dependency (typeof (DroidDataBasePath))]
namespace App13.Droid
{
    public class DroidDataBasePath : IDataBasePath
    {
        public string GetPath()
        {
            string path= Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "todo.db");

            return path;
        }
    }
}