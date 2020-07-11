using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BoardGameKeeper.ViewModels;

namespace BoardGameKeeper.Views
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseGamePage : ContentPage
	{
		ChooseGameViewModel viewModel;

		public ChooseGamePage()
		{
			InitializeComponent();
			viewModel = new ChooseGameViewModel();
			gameNameText.SetBinding(Label.TextProperty, new Binding("ChosenGameName", source: viewModel));
		}

		void OnChooseButtonClicked(object sender, EventArgs args)
		{
			GetNewGame();
		}

		async void GetNewGame()
		{
			bool newGameChosen = viewModel.ChooseGame();
			// changes ChosenGame in the model view
			if (!newGameChosen)
			{
				await DisplayAlert("No games in rotation.", "Please add games to rotation and try again.", "OK");
			}
		}
	}
}
