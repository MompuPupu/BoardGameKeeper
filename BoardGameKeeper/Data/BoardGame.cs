using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BoardGameKeeper.Data
{
	public class BoardGame
	{
		[PrimaryKey,AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public int TimesPlayed { get; set; }

		private bool inRotation;
		public bool InRotation 
		{ 
			get
			{
				return this.inRotation;
			}
			set
			{
				this.inRotation = value;
				BoardGameDatabase.ManageGameInRotation(this);
			}
		}
		public Date DateLastPlayed { get; set; }

		public BoardGame(string name, bool inRotation = true)
		{
			this.Name = name;
			this.InRotation = inRotation;
			this.DateLastPlayed = new Date(2000, 1, 1);
		}

		public BoardGame()
		{

		}

		public void SetupBoardGame(string name, bool inRotation = true)
		{
			this.Name = name;
			this.InRotation = inRotation;
			this.DateLastPlayed = new Date(2000, 1, 1);
		}

	}


}
