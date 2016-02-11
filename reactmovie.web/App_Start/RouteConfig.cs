using System.Web.Mvc;
using System.Web.Routing;

namespace reactmovie.web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Movies",
                "moviebyname",
                new { controller = "Home", action = "GetMovieByName", id = UrlParameter.Optional },
                new string[] { "reactmovie.web.Controllers" }
            );

            routes.MapRoute(
                "MatrixMovies",
                "matrixmovies",
                new { controller = "Home", action = "GetMatrixMovies", id = UrlParameter.Optional },
                new string[] { "reactmovie.web.Controllers" }
            );

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "reactmovie.web.Controllers" }
            );
        }
    }
}
