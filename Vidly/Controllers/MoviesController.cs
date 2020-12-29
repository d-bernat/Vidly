using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public async Task<ActionResult> Index()
        {
            var viewModel = new RandomMovieViewModel();
            return View(viewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var viewModel = new RandomMovieViewModel();
            var movie = viewModel.Movies.FirstOrDefault(c => c.Id == id);
            if (movie != null)
            {
                return View(movie);
            }

            return HttpNotFound();
        }
        //public async Task<ActionResult> Edit(int id)
        //{
        //    return Content("id: " + id);
        //}

        //public async Task<ActionResult> Index(int? pageIndex, string sortBy)
        //{
        //    var page = pageIndex ?? 1;
        //    var sort = string.IsNullOrWhiteSpace(sortBy) ? "Name": sortBy;

        //    return Content($"pageIndex: {page}, sortBy: {sort}");

        //}

        //[Route("movies/released/{year:regex(\\d{4}):range(2015, 2020)}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{

        //    return Content($"year: {year}, month: {month}");
        //}
    }
}