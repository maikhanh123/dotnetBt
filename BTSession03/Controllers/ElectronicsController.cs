using BTSession03.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BTSession03.Controllers
{
    public class ElectronicsController : Controller
    {
        private ApplicationDbContext _context;

        public ElectronicsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Electronics
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryElectronicPartial()
        {
            var categoryElectronics = _context.CategoryElectronics.ToList();
            var category = new List<Category>();
            foreach (var categoryElectronic in categoryElectronics)
            { 
                var temp = new Category();
                temp.Id = categoryElectronic.Id;
                temp.Name = categoryElectronic.Name;
                category.Add(temp);
            }
            return PartialView("_CategoryPartial", category);
        }

        public ActionResult CreateElectronic()
        {
            var viewModel = new CreateViewModel()
            {
                CategoryElectronics = _context.CategoryElectronics.ToList()
            };
            return View("~/Views/Shared/CreateViewModel.cshtml", viewModel);
        }

        public ActionResult CreateCategoryElectronic()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateCategoryElectronic(CategoryElectronic categoryElectronic)
        {
            var category = categoryElectronic;
            if (category == null)
            {
                return View();
            }

            _context.CategoryElectronics.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}