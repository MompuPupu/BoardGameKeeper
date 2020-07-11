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
		public ObservableCollection<BoardGame> AllGames { get; set; }

		public GameListViewModel()
		{
			AllGames = BoardGameDatabase.AllGames;
		}
	}
}
