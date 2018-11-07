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
            return View("~/Views/Shared/CategoryViewModel.cshtml");
        }

        [HttpPost]
        public ActionResult CreateCategoryClother(Category category)
        {
            if (category.Name == null)
            {
                return View("~/Views/Shared/CategoryViewModel.cshtml");
            }

            var categoryClother = new CategoryClother();
            categoryClother.Name = category.Name;

            _context.CategoryClothers.Add(categoryClother);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateClother()
        {
            var viewModel = new CreateViewModel()
            {
                CategoryClother = _context.CategoryClothers.ToList()
            };
            return View("~/Views/Shared/CreateViewModel.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult CreateClother(CreateViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                var createViewModel = new CreateViewModel()
                {
                    CategoryClother = _context.CategoryClothers.ToList()
                };
                return View("~/Views/Shared/CreateViewModel.cshtml", createViewModel);
            }

            var clother = new Clother
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                PriceReduce = viewModel.PriceReduce,
                ImageUrl = viewModel.ImageUrl,
                CategoryClotherId = viewModel.CategoryId
                
            };

            _context.Clothers.Add(clother);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}