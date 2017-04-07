using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App13;
using System.IO;
using Windows.Storage;
using App13.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(DataBasePathUWP))]
namespace App13.UWP
{
    public class DataBasePathUWP : IDataBasePath
    {
        public string GetPath()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "todo.db");
            return path;
        }
    }
}
