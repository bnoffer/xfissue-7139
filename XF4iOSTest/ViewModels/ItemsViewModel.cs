using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XF4iOSTest.Models;
using XF4iOSTest.Views;

using Prism.Commands;
using Prism.Navigation;

namespace XF4iOSTest.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            NavigateToDetailsCommand = new DelegateCommand<Item>(NavigateToDetailsAction);
            NavigateToNewCommand = new DelegateCommand(NavigateToNewAction);

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public DelegateCommand<Item> NavigateToDetailsCommand { get; set; }
        void NavigateToDetailsAction(Item item)
        {
            var parameters = new NavigationParameters();
            parameters.Add("item", item);
            NavigationService.NavigateAsync(new Uri("ItemDetailPage", UriKind.Relative), parameters);
        }

        public DelegateCommand NavigateToNewCommand { get; set; }
        void NavigateToNewAction()
        {
            NavigationService.NavigateAsync(new Uri("NewItemPage", UriKind.Relative));
        }
    }
}