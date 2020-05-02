using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BoardGameKeeper.Data
{
	public class BoardGame
	{
		public delegate void InRotationEventHandler(BoardGame sender);
		public static event InRotationEventHandler OnInRotationChanged;

		[PrimaryKey,AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public int TimesPlayed { get; set; }
		public bool InRotation { get; set; }
		public Date DateLastPlayed { get; set; }

		public BoardGame(string name, bool inRotation = true)
		{
			this.Name = name;
			this.InRotation = inRotation;
			this.DateLastPlayed = new Date(2000, 1, 1);

		}
	}
}
