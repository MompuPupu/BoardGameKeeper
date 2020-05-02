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
			AllGames = new ObservableCollection<BoardGame>()
			{
				new BoardGame("Terra Mystica"),
				new BoardGame("Spirit Island", false),
				new BoardGame("Suburbia"),
				new BoardGame("Agricola"),
				new BoardGame("Machina Arcana")
			};
			InitiliaseGamesInRotationList();
		}

		private static void InitiliaseGamesInRotationList()
		{
			GamesInRotation = new ObservableCollection<BoardGame>();
			foreach (BoardGame game in AllGames)
			{
				ManageGameInRotation(game);
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
		


		//TODO: Implement
	}
}
