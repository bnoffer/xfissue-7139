using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using RealDigital.Ecommerce.App;
using RealDigital.Ecommerce.App.Models;

namespace XF4iOSTest.Droid
{
    [Activity(Label = "XF4iOSTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            #region ROSSO
#if PREPROD_BUILD
            Gateway.ProductionMode = ProductionMode.PreProd;
            Real.ROSSO.UserManager.Init(Real.ROSSO.Profile.ProfileMode.PreProd, Real.ROSSO.Profile.ProfilePlatform.Android);
#else
            Gateway.ProductionMode = ProductionMode.Live;
            Real.ROSSO.UserManager.Init(Real.ROSSO.Profile.ProfileMode.Live, Real.ROSSO.Profile.ProfilePlatform.Android);
#endif
#if DEBUG
            Real.ROSSO.Logging.Log.ActiveLogLevel = Real.ROSSO.Logging.LogLevel.Debug;
            Real.ROSSO.Logging.Log.NewLogEntry += (object sender, Real.ROSSO.Logging.LogEventArgs e) => Track.Event("ROSSO", e.ToString());
#endif
            #endregion

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}