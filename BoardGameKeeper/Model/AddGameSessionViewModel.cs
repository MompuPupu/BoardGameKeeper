using BoardGameKeeper.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace BoardGameKeeper.Model
{
	class AddGameSessionViewModel
	{
		public ObservableCollection<BoardGame> AllGames { get; set; }

		public AddGameSessionViewModel()
		{
			AllGames = BoardGameDatabase.AllGames;
		}

		public void AddSession()
		{

		}

	}
}
