using BoardGameKeeper.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Diagnostics;

namespace BoardGameKeeper.Model
{
	class NoBiasGameChooser : GameChooser
	{

		public override ChooserBias ChooserBias => ChooserBias.NOBIAS;

		public NoBiasGameChooser()
		{

		}

		public override BoardGame ChooseGame(ObservableCollection<BoardGame> games)
		{
			if (games.Count == 1)
			{
				return games[0];
			}
			else
			{
				BoardGame newGame = games[rnd.Next(games.Count)];

				Debug.WriteLine("Game chosen:  " + newGame.Name);
				return newGame;
			}
		}
	}
}
