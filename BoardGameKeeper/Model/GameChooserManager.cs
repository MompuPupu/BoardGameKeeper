using System;
using System.Collections.Generic;
using System.Text;
using BoardGameKeeper.Data;

namespace BoardGameKeeper.Model
{
	public enum ChooserBias
	{
		NOBIAS,
		LASTPLAYED,
		TIMESPLAYED
	}

	public static class GameChooserManager
	{
		private static Dictionary<ChooserBias, BaseGameChooser> gameChoosers;

		static GameChooserManager()
		{
			gameChoosers = new Dictionary<ChooserBias, BaseGameChooser>
			{
				{ ChooserBias.NOBIAS, new NoBiasGameChooser() }
			};

		}

		public static BoardGame ChooseGame()
		{
			return gameChoosers[Options.currentBias].ChooseGame(BoardGameDatabase.GamesInRotation);
		}
	}
}
