using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using reactmovie.web.Models;

namespace reactmovie.web.Providers
{
    public class MovieProvider : IMovieProvider
    {
        public MovieData GetMovieByName(string title)
        {
            using (var client = new HttpClient())
            {
                var movieData = new MovieData();
                // New code:
                client.BaseAddress = new Uri("http://api.myapifilms.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                var response = client.GetAsync("imdb/idIMDB?title=" + title + "&token=" + ConfigurationManager.AppSettings["myappfilmsApiKey"] + "&limit=10").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var deserializedData = JsonConvert.DeserializeObject<MovieObject>(data);
                    return deserializedData.Data;
                }
                return movieData;
            }
        }
    }
}