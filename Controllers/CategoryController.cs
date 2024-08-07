using Microsoft.AspNetCore.Mvc;

namespace ecomapp
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.categories.ToList();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category obj)
        {
            if (obj.DisplayOrder == 69)
            {
                ModelState.AddModelError("Name", "The number should not equal to 6ix9ine");
            }
            if (ModelState.IsValid)
            {

                _db.categories.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}