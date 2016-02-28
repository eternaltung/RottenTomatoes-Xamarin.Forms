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
		List<Movie> movies, dvds, searchData;

		public MainView ()
		{
			InitializeComponent ();
		}

		private async void TabPageChanged(object sender, EventArgs e)
		{
			switch (this.CurrentPage.Title) {
			case "Movies":
				this.Title = "Box Office";
				if (movies == null) 
					movies = await Util.Utility.GetMovieData($"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey={apikey}&limit=20");
				MovieListView.ItemsSource = movies;
				MovieProgress.IsRunning = false;
				searchData = movies; 
				break;
			case "DVD":
				this.Title = "DVD Top Rentals";
				if (dvds == null) 
					dvds = await Util.Utility.GetMovieData($"http://api.rottentomatoes.com/api/public/v1.0/lists/dvds/top_rentals.json?apikey={apikey}&limit=20");
				DVDListView.ItemsSource = dvds;
				DVDProgress.IsRunning = false;
				searchData = dvds;
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

