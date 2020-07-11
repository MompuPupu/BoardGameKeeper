using System;
using System.Collections.Generic;
using System.Text;
using BoardGameKeeper.Data;
using System.Collections.ObjectModel;

namespace BoardGameKeeper.Model
{ 
	abstract class GameChooser
	{
		protected Random rnd = new Random();
		public abstract BoardGame ChooseGame(ObservableCollection<BoardGame> games);

		public abstract ChooserBias ChooserBias { get; }

	}
}
