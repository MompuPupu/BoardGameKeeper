using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BoardGameKeeper.Data
{
	class Player
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public int GamesPlayed { get; set; }
		public List<int> SessionsPlayed { get; set; }
		public int GamesWon { get; set; }

		public Player(string name)
		{
			this.Name = name;
			SessionsPlayed = new List<int>();
		}
	}
}
