using System;

using XF4iOSTest.Models;
using Prism.Navigation;

namespace XF4iOSTest.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }

        public ItemDetailViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Item = new Item();
            Title = "";
        }

        public override void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("item"))
            {
                Item = (Item)parameters["item"];
            }
        }
    }
}
