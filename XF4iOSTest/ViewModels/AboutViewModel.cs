﻿using System;
using System.Windows.Input;

using Xamarin.Forms;
using Prism.Navigation;

namespace XF4iOSTest.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}