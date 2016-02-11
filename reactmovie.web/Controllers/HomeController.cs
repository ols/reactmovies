using System;
using System.Web.Mvc;
using System.Web.UI;
using reactmovie.web.Providers;

namespace reactmovie.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieProvider _movieProvider;

        public HomeController(IMovieProvider movieProvider)
        {
            _movieProvider = movieProvider;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public JsonResult GetMovieByName(string title)
        {
            return Json(_movieProvider.GetMovieByName(title), JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public JsonResult GetMatrixMovies()
        {
            return Json(_movieProvider.GetMovieByName(), JsonRequestBehavior.AllowGet);
        }
    }
}