using System;
using System.Collections.Generic;
using System.Text;
using BoardGameKeeper.Data;

namespace BoardGameKeeper.ViewModels
{
	class AddGameViewModel
	{
		public void AddGameToDatabase(string name, bool inRotation)
		{
			BoardGame newGame = new BoardGame(name, inRotation);
			BoardGameDatabase.AddGameToDatabase(newGame);
		}
	}
}
