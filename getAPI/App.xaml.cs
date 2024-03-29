﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace getAPI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        public static string DatabasePath = string.Empty;
        public App(string databasePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new getAPI.MainPage());

            DatabasePath = databasePath;
        }

        protected override void OnStart()
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
