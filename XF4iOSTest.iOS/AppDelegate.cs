using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using RealDigital.Ecommerce.App;
using RealDigital.Ecommerce.App.Models;

namespace XF4iOSTest.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            #region ROSSO
#if PREPROD_BUILD
            Real.ROSSO.UserManager.Init(Real.ROSSO.Profile.ProfileMode.PreProd, Real.ROSSO.Profile.ProfilePlatform.iOS);
            Gateway.ProductionMode = ProductionMode.PreProd;
#else
            Real.ROSSO.UserManager.Init(Real.ROSSO.Profile.ProfileMode.Live, Real.ROSSO.Profile.ProfilePlatform.iOS);
            Gateway.ProductionMode = ProductionMode.Live;
#endif
#if DEBUG
            Real.ROSSO.Logging.Log.ActiveLogLevel = Real.ROSSO.Logging.LogLevel.Debug;
            Real.ROSSO.Logging.Log.NewLogEntry += (object sender, Real.ROSSO.Logging.LogEventArgs e) => Track.Event("ROSSO", e.ToString());
#endif
            #endregion

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
