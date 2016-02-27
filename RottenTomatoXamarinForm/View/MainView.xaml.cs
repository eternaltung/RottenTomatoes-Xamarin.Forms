using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RottenTomatoXamarinForm
{
	public partial class MainView : TabbedPage
	{
        const string apikey = "";
		List<Movie> movies;

		public MainView ()
		{
			InitializeComponent ();
			Title = "Box Office";
			UpdateUI($"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey={apikey}&limit=20");
		}

		private async void UpdateUI(string url)
        {
			movies = await Util.Utility.GetMovieData(url);
            MovieListView.ItemsSource = movies;
            
        }

		private void TabPageChanged(object sender, EventArgs e)
		{
			switch (this.CurrentPage.Title) {
			case "Movies":
				this.Title = "Box Office";
				break;
			case "DVD":
				this.Title = "DVD Top Rentals";
				break;
			case "Search":
				this.Title = "Search";
				break;
			}
		}

		private async void MovieListViewSelected (object sender, SelectedItemChangedEventArgs e)
		{
			//DisplayAlert("Title",e.SelectedItem.ToString(),"OK");
			if (e.SelectedItem != null) {
				await Navigation.PushAsync(new DetailPage(e.SelectedItem as Movie));
				((ListView)sender).SelectedItem = null;
			}
		}
	}
}

