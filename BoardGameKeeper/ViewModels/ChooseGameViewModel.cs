using System;
using System.Collections.Generic;
using System.Text;
using BoardGameKeeper.Model;

namespace BoardGameKeeper.ViewModels
{
	class ChooseGameViewModel
	{
		public string ChosenGameName { get; set; }

		//TODO: implement ChooseGame();
		public void ChooseGame()
		{
			ChosenGameName = GameChooserManager.ChooseGame().Name;
		}
	}
}
