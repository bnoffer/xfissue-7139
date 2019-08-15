using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF4iOSTest.Services;
using XF4iOSTest.ViewModels;
using XF4iOSTest.Views;

using Prism;
using Prism.Ioc;
using Prism.DryIoc;
using Prism.Navigation;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using RealDigital.Ecommerce.App;
using RealDigital.Ecommerce.App.Events;
using RealDigital.Ecommerce.App.Events.Models;

namespace XF4iOSTest
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            
            NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutViewModel>();
            containerRegistry.RegisterForNavigation<ItemDetailPage, ItemDetailViewModel>();
            containerRegistry.RegisterForNavigation<ItemsPage, ItemsViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<NewItemPage>();
        }

        protected override void OnStart()
        {
            base.OnStart();

            AppCenter.Start("ios=8f5d9710-70cb-454e-950f-120e1cfa965c;" +
                            "android=d2fb3048-bcd3-49d7-8384-85a0a7bcbeee",
                            typeof(Analytics), typeof(Crashes));

            DependencyService.Register<MockDataStore>();

            StartBackend();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            base.OnResume();
            // Handle when your app resumes
        }

        void StartBackend()
        {
            string tag = this + ".LoadDatabase";
            try
            {
                EventsManager.Instance.Storage.Loaded += OnDatabaseLoaded;

                Gateway.Instance.Start();
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }

        public void OnDatabaseLoaded(Object sender, ObjectEventArgs e)
        {
            string tag = this + ".OnStoreDataLoaded";
            try
            {
                EventsManager.Instance.Storage.Loaded -= OnDatabaseLoaded;

            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
    }
}
