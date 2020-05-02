using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameKeeper.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	//TODO: fix code-behind (xaml implemented)
	public partial class GameListPage : ContentPage
	{
		public ObservableCollection<string> Items { get; set; }

		public GameListPage()
		{
			InitializeComponent();

			Items = new ObservableCollection<string>
			{
				"Item 1",
				"Item 2",
				"Item 3",
				"Item 4",
				"Item 5"
			};

			//MyListView.ItemsSource = Items;
		}

		async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null)
				return;

			await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

			//Deselect Item
			((ListView)sender).SelectedItem = null;
		}

		public void HandleGameTapped(object sender, ItemTappedEventArgs e)
		{

		}

	}
}
