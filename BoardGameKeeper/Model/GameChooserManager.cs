using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
		private static Dictionary<ChooserBias, GameChooser> gameChoosers = new Dictionary<ChooserBias, GameChooser>();
		private static bool isInitialised = false;


		private static void Initialise()
		{
			// Need to clear to be certain that we're not doubling up if Initialise() runs twice for some reason
			gameChoosers.Clear();


			// Looks for the assembly of GameChoosers and loads all the types into an IEnumerable. 
			// Check for abstract to be sure we don't get the parent
			var allGameChoosers = Assembly.GetAssembly(typeof(GameChooser)).
				GetTypes().Where(t => typeof(GameChooser).IsAssignableFrom(t) && t.IsAbstract == false);


			// Runs through each GameChooser type in the list, creates an instance, and loads that instance into the dictionary
			foreach (var gameChooser in allGameChoosers)
			{
				GameChooser chooserInstance = Activator.CreateInstance(gameChooser) as GameChooser;
				gameChoosers.Add(chooserInstance.ChooserBias, chooserInstance);
			}

			isInitialised = true;
		}

		public static BoardGame ChooseGame()
		{
			if (isInitialised == false)
				Initialise();

			return gameChoosers[Options.currentBias].ChooseGame(BoardGameDatabase.GamesInRotation);
		}
	}
}
