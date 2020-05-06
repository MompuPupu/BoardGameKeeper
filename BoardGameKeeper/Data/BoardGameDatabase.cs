using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace BoardGameKeeper.Data
{
	public static class BoardGameDatabase
	{
		public static ObservableCollection<BoardGame> AllGames { get; set; }
		public static ObservableCollection<BoardGame> GamesInRotation { get; set; }

		static BoardGameDatabase() 
		{
			GamesInRotation = new ObservableCollection<BoardGame>();
			AllGames = new ObservableCollection<BoardGame>
			{
				new BoardGame("Terra Mystica"),
				new BoardGame("Spirit Island", false),
				new BoardGame("Suburbia"),
				new BoardGame("Agricola"),
				new BoardGame("Machina Arcana")
			};
		}
		

		public static void RefreshGamesInRotationList(ObservableCollection<BoardGame> newInRotations)
		{
			/* Runs through the new list of new bools and compares them to the inrotation on each boardgame in the all list.
				Needs to be all list as the gamelistview uses all the games. */
			
			for (int i = 0; i < newInRotations.Count; i++)
			{
				if (!(AllGames[i].InRotation == newInRotations[i].InRotation))
				{
					ManageGameInRotation(AllGames[i]);
				}
			}
		}

		public static void ManageGameInRotation(BoardGame game)
		{
			if (game.InRotation == true && !GamesInRotation.Contains(game))
			{
				GamesInRotation.Add(game);
			}
			else
			{
				if (GamesInRotation.Contains(game))
				{
					GamesInRotation.Remove(game);
				}
			}
		}
		public static void AddGameToDatabase(BoardGame newGame)
		{
			AllGames.Add(newGame);
			if (newGame.InRotation == true && !GamesInRotation.Contains(newGame))
			{
				GamesInRotation.Add(newGame);
			}
		}

		public static void DeleteGameFromDatabase(BoardGame gameToDelete)
		{
			AllGames.Remove(gameToDelete);
			if (GamesInRotation.Contains(gameToDelete))
			{
				GamesInRotation.Remove(gameToDelete);
			}
		}
	}
}
