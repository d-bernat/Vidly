using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context = ApplicationDbContext.Create();

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = new CustomerViewModel { Customers = _context.Customers.Include(c => c.MembershipType).ToList() };
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                return View(customer);
            }

            return HttpNotFound();
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel { Customer = new Customer(), MembershipTypes = _context.MembershipTypes };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel { Customer = customer, MembershipTypes = _context.MembershipTypes.ToList() };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerEntity = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                if (customerEntity != null)
                {
                    customerEntity.Name = customer.Name;
                    customerEntity.BirthDate = customer.BirthDate;
                    customerEntity.MembershipTypeId = customer.MembershipTypeId;
                    customerEntity.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                }

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new CustomerFormViewModel
            {
                Customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id),
                MembershipTypes = _context.MembershipTypes
            };
            return View("CustomerForm", viewModel);
        }
    }
}