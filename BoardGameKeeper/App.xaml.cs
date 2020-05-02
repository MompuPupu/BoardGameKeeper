using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BoardGameKeeper.Views;

namespace BoardGameKeeper
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new TabbedHome();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
