using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace getAPI.Droid
{
    [Activity(Label = "getAPI", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //Name of the file  
            string dbName = "notes.db3";

            //the database has to be stored in a personal folder 
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            //Combining the name of the file and the path of the directory where it will be stored 
            // Path.combine() This method makes sure that these strings are correctly combined into a string that is formatted as a path. 
            //! added using System.IO; 
            string dbPath = Path.Combine(folderPath, dbName);

            //I am passing the dbPath to the second overload of the App's constuctor. 
            LoadApplication(new App(dbPath));
           // LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}