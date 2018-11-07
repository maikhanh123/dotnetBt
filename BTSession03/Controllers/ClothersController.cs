using BTSession03.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BTSession03.Controllers
{
    public class ClothersController : Controller
    {
        private ApplicationDbContext _context;

        public ClothersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Clothers
        public ActionResult Index()
        {
            var clothers = _context.Clothers.ToList();
            
            return View(clothers);
        }

        public ActionResult CategoryClotherPartial()
        {
            var categoryClothers = _context.CategoryClothers.ToList();
            var category = new List<Category>();
            foreach (var categoryClother in categoryClothers)
            {
                var temp = new Category();
                temp.Id = categoryClother.Id;
                temp.Name = categoryClother.Name;
                category.Add(temp);
            }
            
            return PartialView("_CategoryPartial", category);
        }

        public ActionResult CreateCategoryClother()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategoryClother(CategoryClother categoryClother)
        {
            var category = categoryClother;
            if (category == null)
            {
                return View();
            }

            _context.CategoryClothers.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateClother()
        {
//            var viewModel = new ClotherViewModel {CategoryClother = _context.CategoryClothers.ToList()};
//            return View(viewModel);

            var viewModel = new CreateViewModel()
            {
                CategoryClother = _context.CategoryClothers.ToList()
            };
            return View("~/Views/Shared/CreateViewModel.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult CreateClother(ClotherViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                viewModel = new ClotherViewModel { CategoryClother = _context.CategoryClothers.ToList() };
                return View(viewModel);
            }

            var clother = new Clother
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                PriceReduce = viewModel.PriceReduce,
                ImageUrl = viewModel.ImageUrl,
                CategoryClotherId = viewModel.CategoryClotherId
                
            };

            _context.Clothers.Add(clother);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}