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
            
            UpdateUI();
		}

        private async Task UpdateUI()
        {
            movies = await Util.Utility.GetMovieData($"http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?apikey={apikey}&limit=20");
            MovieListView.ItemsSource = movies;
            
        }
	}
}

