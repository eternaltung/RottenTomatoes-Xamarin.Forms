using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RottenTomatoXamarinForm.Util
{
    public class Utility
    {
        public static async Task<List<Movie>> GetMovieData(string url)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<MovieModel>(json).movies;
        }
    }

    
}
