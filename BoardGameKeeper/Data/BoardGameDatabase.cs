using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SQLite;
using System.Threading.Tasks;

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

		public static void ManageGameInRotation(BoardGame game)
		{
			if (game.InRotation == true && !GamesInRotation.Contains(game))
			{
				GamesInRotation.Add(game);
			}
			else if (game.InRotation == false && GamesInRotation.Contains(game))
			{
				GamesInRotation.Remove(game);
			}

		}
		public static void AddGameToDatabase(BoardGame newGame)
		{
			AllGames.Add(newGame);
			ManageGameInRotation(newGame);
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

	public class BoardGameDatabaseSQL
	{
		private bool DatabaseChanged = true;
		private ObservableCollection<BoardGame> allGames;
		public ObservableCollection<BoardGame> AllGames 
		{ 
			get 
			{
				GetBoardGames();
				return allGames; 
			}
			set 
			{ 
				SetBoardGameDatabase(value); 
			} 
		}

		private async void GetBoardGames()
		{
			List<BoardGame> gameList = await RetrieveBoardGameDatabaseAsync();
			allGames = new ObservableCollection<BoardGame>(gameList);
			DatabaseChanged = false;
		}

		private Task<List<BoardGame>> RetrieveBoardGameDatabaseAsync()
		{
			return Database.Table<BoardGame>().ToListAsync();
		}

		private void SetBoardGameDatabase(ObservableCollection<BoardGame> allGames)
		{
			foreach (BoardGame game in allGames)
			{
				AddGameToDatabase(game);
			}
			DatabaseChanged = true;
			throw new NotImplementedException();
		}

		public ObservableCollection<BoardGame> GamesInRotation { get; set; }

		readonly SQLiteAsyncConnection Database;

		public BoardGameDatabaseSQL(string databasePath)
		{
			Database = new SQLiteAsyncConnection(databasePath);
			Database.CreateTableAsync<BoardGame>().Wait();

			//initialise games in rotation list
			GamesInRotation = new ObservableCollection<BoardGame>();
			foreach (BoardGame game in AllGames)
			{
				ManageGameInRotation(game);
			}
		}

		public Task<int> AddGameToDatabase(BoardGame game)
		{
			if (game.ID != 0)
			{
				return Database.UpdateAsync(game);
			}
			else
			{
				return Database.InsertAsync(game);
			}
		}

		public void DeleteGameFromDatabase(BoardGame gameToDelete)
		{
			DatabaseChanged = true;
			AllGames.Remove(gameToDelete);
			if (GamesInRotation.Contains(gameToDelete))
			{
				GamesInRotation.Remove(gameToDelete);
			}
		}

		public void ManageGameInRotation(BoardGame game)
		{
			if (game.InRotation == true && !GamesInRotation.Contains(game))
			{
				GamesInRotation.Add(game);
			}
			else if (game.InRotation == false && GamesInRotation.Contains(game))
			{
				GamesInRotation.Remove(game);
			}
		}
	}
}
