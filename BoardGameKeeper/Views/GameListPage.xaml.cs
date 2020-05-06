using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BoardGameKeeper.ViewModels;
using BoardGameKeeper.Data;

namespace BoardGameKeeper.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class GameListPage : ContentPage
	{
		GameListViewModel viewModel;

		public GameListPage()
		{
			InitializeComponent();
			viewModel = new GameListViewModel();
			gameListView.ItemsSource = viewModel.AllGames;
		}

		private async void HandleGameTapped(object sender, ItemTappedEventArgs e)
		{
			if (e.Item == null)
				return;

			//TODO: Write code to go to another page for the boardgame itself
			await DisplayAlert("Game was tapped.", "A game was tapped", "OK");

			//Deselect game
			((ListView)sender).SelectedItem = null;
		}

		// Triggers change to bool variable in the Viewmodel to reset the gamesInRotation list in the BGDB
		private void InRotationChanged(object sender, CheckedChangedEventArgs e)
		{
			viewModel.InRotationCheckedChanged();
		}

		protected override void OnDisappearing()
		{
			viewModel.CheckForChangedInRotation();
		}

	}
}
