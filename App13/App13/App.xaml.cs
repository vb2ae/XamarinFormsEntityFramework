using App13.PageModels;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace App13
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var homePage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<ToDoPageModel>();
            var navConatiner = new FreshMvvm.FreshNavigationContainer(homePage);
            MainPage = navConatiner;

        }

        protected async override void OnStart()
        {
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
