using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BoardGameKeeper.ViewModels;

namespace BoardGameKeeper.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

	public partial class AddGamePage : ContentPage
	{
		AddGameViewModel viewModel;

		public AddGamePage()
		{
			InitializeComponent();
			viewModel = new AddGameViewModel();
		}

		async void OnAddGameButtonClicked(object sender, EventArgs e)
		{
			if (!(gameNameEntry.Text == ""))
			{
				viewModel.AddGameToDatabase(gameNameEntry.Text, inRotationCheckBox.IsChecked);
				await DisplayAlert("Game Added!", gameNameEntry.Text + " added to database.", "OK");
				gameNameEntry.Text = "";
			}
			else
			{
				await DisplayAlert("Invalid Entry", "Please enter the name of the game.", "OK");
			}
		}
	}
}