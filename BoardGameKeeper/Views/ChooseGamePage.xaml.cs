using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BoardGameKeeper.ViewModels;


//TODO: Write XAML for this page...

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

		void GetNewGame()
		{
			// changes ChosenGame in the model view		
			viewModel.ChooseGame();
		}
	}
}
