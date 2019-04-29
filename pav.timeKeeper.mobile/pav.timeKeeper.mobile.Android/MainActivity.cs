using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using pav.timeKeeper.mobile.Droid.Helpers;

namespace pav.timeKeeper.mobile.Droid
{

    //    Icon = "@mipmap/launcher_foreground", RoundIcon = "@mipmap/launcher_foreground",
    [Activity(Label = "Timekeeper", Theme = "@style/MainTheme", MainLauncher = false,
              Icon = "@mipmap/ic_launcher",  RoundIcon = "@mipmap/ic_launcher",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string dbPath = FileAccessHelper.GetLocalFilePath("projects.db3");

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            
           
           // FormsMaterial.Init(this, savedInstanceState);
            
            LoadApplication(new App(dbPath));
        }
    }
}