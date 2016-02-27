using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace RottenTomatoXamarinForm
{
	public partial class DetailPage : ContentPage
	{
		private Movie movie;

		public DetailPage (Movie _movie)
		{
			InitializeComponent ();
			movie = _movie;
			SetUI ();
		}

		private async void SetUI()
		{
			//his.BackGroundImg.Source = ImageSource.FromUri (new Uri (movie.posters.thumbnail));
			this.BackGroundImg.Source = new UriImageSource () {
				Uri = new Uri (movie.posters.thumbnail)
			};
			//Task<UriImageSource> highImg = Task<UriImageSource>.Factory.StartNew (() => ImageSource.FromUri (new Uri (convertToHighResolutionImg (movie.posters.thumbnail))));
			Task<UriImageSource> highImg = Task<UriImageSource>.Factory.StartNew (() => new UriImageSource () {
				Uri = new Uri (convertToHighResolutionImg (movie.posters.thumbnail)),
				CachingEnabled = false
			});
			this.BackGroundImg.Source = await highImg;
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

