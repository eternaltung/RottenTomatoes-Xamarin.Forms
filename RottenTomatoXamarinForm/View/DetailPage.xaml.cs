using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace RottenTomatoXamarinForm
{
	public partial class DetailPage : ContentPage
	{
		private Movie movie;
		double lastY;
		double defaultTranslateY = 150;

		public DetailPage (Movie _movie)
		{
			InitializeComponent ();
			movie = _movie;
			SetUI ();
		}

		private async void SetUI()
		{
			this.Title = movie.title;
			TitleLabel.Text = $"{movie.title}({movie.year}) {movie.runtime}mins";
			DescLabel.Text = movie.synopsis;
			//DetailView.HeightRequest = 300;
			//DetailView.BackgroundColor = Color.Gray;
			//DetailView.Opacity = 0.8;
			DetailView.TranslationY = defaultTranslateY;

			this.BackGroundImg.Source = new UriImageSource () {
				Uri = new Uri (movie.posters.thumbnail)
			};
			Task<UriImageSource> highImg = Task<UriImageSource>.Factory.StartNew (() => new UriImageSource () {
				Uri = new Uri (convertToHighResolutionImg (movie.posters.thumbnail)),
				CachingEnabled = false
			});
			this.BackGroundImg.Source = await highImg;
		}

		void OnPanUpdated (object sender, PanUpdatedEventArgs e)
		{
			if (e.StatusType == GestureStatus.Started) {
				lastY = DetailView.TranslationY;
			}

			if (e.TotalY < 0 && DetailView.TranslationY > 0) {
				//up
				DetailView.TranslationY = lastY + e.TotalY;
				if (DetailView.TranslationY < 0) 
					DetailView.TranslationY = 0;				
			} 
			else if (e.TotalY >0 && DetailView.TranslationY < 150){	
				//down
				DetailView.TranslationY = lastY + e.TotalY;
				if (DetailView.TranslationY > 150)
					DetailView.TranslationY = 150;
			}


		}

		/// <summary>
		/// Converts to high resolution image.
		/// </summary>
		/// <returns>url</returns>
		/// <param name="url">URL.</param>
		private string convertToHighResolutionImg(string url)
		{
			return "https://content6.flixster.com/" + url.Substring(url.IndexOf("cloudfront.net/") + "cloudfront.net/".Length);
		} 
	}
}

