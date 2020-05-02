using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BoardGameKeeper.Data
{
	class GameSession
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public BoardGame Game { get; set; }
		public Dictionary<Player,int> PlayersAndScores { get; set; }
		public Player Winner { get; set; }
		public bool EveryoneWins { get; set; }
		public Date DatePlayed { get; set; }

		public GameSession(BoardGame game, Date date, Dictionary<Player,int> playersAndScores, Player winner)
		{
			this.Game = game;
			this.DatePlayed = date;
			this.PlayersAndScores = playersAndScores;
			this.Winner = winner;
		}

		public GameSession(BoardGame game, Date date, Dictionary<Player, int> playersAndScores, bool everyoneWins)
		{
			this.Game = game;
			this.DatePlayed = date;
			this.PlayersAndScores = playersAndScores;
			this.EveryoneWins = everyoneWins;
		}
	}
}
