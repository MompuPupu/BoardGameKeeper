using BoardGameKeeper.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace BoardGameKeeper.Model
{
	class NoBiasGameChooser : BaseGameChooser
	{
		public NoBiasGameChooser()
		{

		}

		public override BoardGame ChooseGame(ObservableCollection<BoardGame> games)
		{
			return games[rnd.Next(0, games.Count - 1)];
		}
	}
}
