using System.Collections.Generic;

namespace reactmovie.web.Models
{
    public class MovieObject
    {
        public MovieData Data { get; set; }
        public MovieAbout About { get; set; }
    }

    public class MovieAbout
    {
        public string Version { get; set; }
    }

    public class MovieData
    {
        public List<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string UrlPoster { get; set; }
        public List<string> Genres { get; set; }
        public string Ratings { get; set; }
        public string Plot { get; set; }
        public string Year { get; set; }
        public string UrlIMDB { get; set; }
    }
}