using System;
using System.Collections.Generic;
using System.Text;
using BoardGameKeeper.Model;
using BoardGameKeeper.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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

		public bool ChooseGame()
		{
			if (CheckForGamesInRotation())
			{
				ChosenGameName = GameChooserManager.ChooseGame().Name;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ChosenGameName"));
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool CheckForGamesInRotation()
		{
			return BoardGameDatabase.GamesInRotation != null;
		}

	}
}
