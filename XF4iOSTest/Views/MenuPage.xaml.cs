using XF4iOSTest.Models;
using XF4iOSTest.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF4iOSTest.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as HomeMenuItem;
            if (item == null)
                return;

            var vm = BindingContext as MenuViewModel;
            vm.ItemSelectedCommand.Execute((int)item.Id);
        }
    }
}