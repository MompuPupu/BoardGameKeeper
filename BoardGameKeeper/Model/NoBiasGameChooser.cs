using BoardGameKeeper.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Diagnostics;

namespace BoardGameKeeper.Model
{
	class NoBiasGameChooser : BaseGameChooser
	{
		public NoBiasGameChooser()
		{

		}

		public override BoardGame ChooseGame(ObservableCollection<BoardGame> games)
		{
			BoardGame newGame = games[rnd.Next(0, games.Count)];

			Debug.WriteLine("Game chosen:  ", newGame.Name);
			return newGame;
		}
	}
}
