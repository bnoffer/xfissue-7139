using System;
using System.Collections.Generic;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using RealDigital.Ecommerce.App;
using RealDigital.Ecommerce.App.Events;
using RealDigital.Ecommerce.App.Events.Models;
using RealDigital.Ecommerce.App.Services.Identity.Models;

namespace XF4iOSTest.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public LoginViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Initialize();
        }

        void Initialize()
        {
            EventsManager.Instance.User.RossoLoginSuccess += OnRossoLoginSuccess;
            EventsManager.Instance.User.RossoLoginFailed += OnRossoLoginFailed;
            EventsManager.Instance.User.HybrisAuthenticationSuccess += OnHybrisAuthenticationSuccess;
            EventsManager.Instance.User.HybrisAuthenticationFailed += OnHybrisAuthenticationFailed;

            LoginCommand = new DelegateCommand(LoginAction);
        }

        public DelegateCommand LoginCommand { get; set; }
        void LoginAction()
        {
            var credentials = new Credentials()
            {
                Username = Username,
                Password = Password
            };
            Gateway.Instance.POST("identity/process/login", credentials);
        }

        public void OnRossoLoginFailed(object sender, ObjectEventArgs e)
        {

        }

        public void OnHybrisAuthenticationFailed(object sender, ObjectEventArgs e)
        {
            
        }

        public void OnRossoLoginSuccess(object sender, ObjectEventArgs e)
        {
            string tag = this + ".OnRossoLoginSucess";
            try
            {
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }


        public void OnHybrisAuthenticationSuccess(object sender, ObjectEventArgs e)
        {
            var tag = this + ".OnHybrisAuthenticationSuccess";
            try
            {
                NavigationService.NavigateAsync(new Uri("/NavigationPage/LoginPage/ItemsPage", UriKind.Absolute));
            }
            catch (Exception ex)
            {
                Track.Exception(tag, ex);
            }
        }
    }
}
