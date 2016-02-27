using System;
using System.Collections.Generic;

namespace RottenTomatoXamarinForm
{
	public class MovieModel
	{
		public List<Movie> movies { get; set; }
	}

	public class Movie
	{
		public string id { get; set; }
		public string title { get; set; }
		public int year { get; set; }
		public string mpaa_rating { get; set; }
		public int? runtime { get; set; }
		public string critics_consensus { get; set; }
		public Release_Dates release_dates { get; set; }
		public Ratings ratings { get; set; }
		public string synopsis { get; set; }
		public Posters posters { get; set; }
		public List<Abridged_Cast> abridged_cast { get; set; }
		public Links1 links { get; set; }
		public Alternate_Ids alternate_ids { get; set; }
	}

	public class Release_Dates
	{
		public string theater { get; set; }
	}

	public class Ratings
	{
		public string critics_rating { get; set; }
		public int critics_score { get; set; }
		public string audience_rating { get; set; }
		public int audience_score { get; set; }
	}

	public class Posters
	{
		public string thumbnail { get; set; }
		public string profile { get; set; }
		public string detailed { get; set; }
		public string original { get; set; }
	}

	public class Links1
	{
		public string self { get; set; }
		public string alternate { get; set; }
		public string cast { get; set; }
		public string reviews { get; set; }
		public string similar { get; set; }
	}

	public class Alternate_Ids
	{
		public string imdb { get; set; }
	}

	public class Abridged_Cast
	{
		public string name { get; set; }
		public string id { get; set; }
		public List<string> characters { get; set; }
	}
}

