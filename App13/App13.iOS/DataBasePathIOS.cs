using App13.iOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(DataBasePathIOS))]
namespace App13.iOS
{
    public class DataBasePathIOS : IDataBasePath
    {
        public string GetPath()
        {
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "todo.db");

            return path;
        }
    }
}
