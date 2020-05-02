using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameKeeper.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddGameSessionPage : ContentPage
	{
		public AddGameSessionPage()
		{
			InitializeComponent();
		}

		private void OnAddGameSessionClicked(object sender, EventArgs args)
		{
			/*TODO: needs to update datelastplayed in boardgame, and add the ID to the list of games played for that game. 
			similar for all players*/
		}

	}
}