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
            var electronic = _context.Electronics.ToList();
            return View(electronic);
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
            ViewBag.Action = "Electronic";
            return View("~/Views/Shared/CreateViewModel.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult CreateElectronic(CreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var createViewModel = new CreateViewModel()
                {
                    CategoryClother = _context.CategoryClothers.ToList()
                };
                ViewBag.Action = "Electronic";
                return View("~/Views/Shared/CreateViewModel.cshtml", createViewModel);
            }

            var electronic = new Electronic()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                PriceReduce = viewModel.PriceReduce,
                Imageurl = viewModel.ImageUrl,
                CategoryElectronicId = viewModel.CategoryId

            };

            _context.Electronics.Add(electronic);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult CreateCategoryElectronic()
        {
            ViewBag.Action = "Electronic";
            return View("~/Views/Shared/CategoryViewModel.cshtml");
        }

        [HttpPost]
        public ActionResult CreateCategoryElectronic(Category category)
        {
            if (category.Name == null)
            {
                ViewBag.Action = "Electronic";
                return View("~/Views/Shared/CategoryViewModel.cshtml");
            }
            var categoryElectronic = new CategoryElectronic();
            categoryElectronic.Name = category.Name;

            _context.CategoryElectronics.Add(categoryElectronic);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        public ActionResult Detail(int id)
        {
            var electronic = _context.Electronics.SingleOrDefault(e => e.Id == id);
            if (electronic == null)
            {
                return HttpNotFound();
            }

            var category = _context.CategoryElectronics.Single(c => c.Id == electronic.CategoryElectronicId);

            var product = new Product
            {
                Id = electronic.Id,
                Name = electronic.Name,
                Description = electronic.Description,
                Imageurl = electronic.Imageurl,
                Price = electronic.Price,
                PriceReduce = electronic.PriceReduce,
                CategoryName = category.Name
            };


            return View("~/Views/Shared/DetailViewModel.cshtml",product);
        }
    }
}