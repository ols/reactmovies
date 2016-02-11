using reactmovie.web.Models;

namespace reactmovie.web.Providers
{
    public interface IMovieProvider
    {
        MovieData GetMovieByName(string title = "matrix");
    }
}