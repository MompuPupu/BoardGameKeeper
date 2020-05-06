using System;
using System.Collections.Generic;
using System.Text;
using BoardGameKeeper.Data;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;

namespace BoardGameKeeper.ViewModels
{
	class GameListViewModel
	{

		public ObservableCollection<BoardGame> AllGames { get; }
		public ObservableCollection<string> Names { get; private set; }
		public ObservableCollection<bool> InRotations { get; set; }

		public bool InRotationChanged { get; private set; }

		public GameListViewModel()
		{
			AllGames = BoardGameDatabase.AllGames;
		}

		public void InRotationCheckedChanged()
		{
			InRotationChanged = true;
		}

		public void CheckForChangedInRotation()
		{
			if (InRotationChanged)
			{
				BoardGameDatabase.RefreshGamesInRotationList(AllGames);
			}
		}

	}
}
