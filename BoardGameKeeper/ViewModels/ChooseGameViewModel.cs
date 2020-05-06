using System;
using System.Collections.Generic;
using System.Text;
using BoardGameKeeper.Model;
using Xamarin.Forms;
using System.ComponentModel;

namespace BoardGameKeeper.ViewModels
{
	class ChooseGameViewModel: INotifyPropertyChanged
	{
		public string ChosenGameName { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public ChooseGameViewModel()
		{
			ChosenGameName = "Click below to choose a game";
		}

		public void ChooseGame()
		{
			ChosenGameName = GameChooserManager.ChooseGame().Name;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ChosenGameName"));
		}
	}
}
