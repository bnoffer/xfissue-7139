using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using XF4iOSTest.Models;
using XF4iOSTest.Services;

using Prism.Mvvm;
using Prism.Navigation;

namespace XF4iOSTest.ViewModels
{
    public class BaseViewModel : BindableBase, IInitialize
    {
        public INavigationService NavigationService { get; private set; }
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public BaseViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
            
        }
    }
}
