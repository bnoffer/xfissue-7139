using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Prism.Commands;
using Prism.Navigation;

using XF4iOSTest.Models;
using XF4iOSTest.Views;

namespace XF4iOSTest.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        List<HomeMenuItem> _menuItems;
        public List<HomeMenuItem> MenuItems
        {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        public MenuViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            MenuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.Login, Title="Login" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };

            ItemSelectedCommand = new DelegateCommand<int>(ItemSelectedAction);
        }

        public DelegateCommand<int> ItemSelectedCommand { get; set; }
        void ItemSelectedAction(int id)
        {
            switch (id)
            {
                case (int)MenuItemType.Browse:
                    NavigationService.NavigateAsync($"{nameof(MainPage)}/{nameof(NavigationPage)}/{nameof(ItemsPage)}");
                    break;
                case (int)MenuItemType.Login:
                    NavigationService.NavigateAsync($"{nameof(MainPage)}/{nameof(NavigationPage)}/{nameof(LoginPage)}");
                    break;
                case (int)MenuItemType.About:
                    NavigationService.NavigateAsync($"{nameof(MainPage)}/{nameof(NavigationPage)}/{nameof(AboutPage)}");
                    break;
            }
        }
    }
}
