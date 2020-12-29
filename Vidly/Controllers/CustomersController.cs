using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public async Task<ActionResult> Index()
        {
            var viewModel = new RandomMovieViewModel();
            return View(viewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            var viewModel = new RandomMovieViewModel();
            var customer = viewModel.Customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View(customer);
            }

            return HttpNotFound();
        }
    }
}