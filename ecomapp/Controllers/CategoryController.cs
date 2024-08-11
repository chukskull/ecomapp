using ecomapp.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ecomapp
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _db.categories.ToList();
            return View(categories);
            // return Ok(categories);
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
                TempData["success"] = "Category Created successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? ctg = _db.categories.Where(u => u.Id == id).FirstOrDefault();

            if (ctg == null)
            {
                return NotFound();

            }
            return View(ctg);
        }
        [HttpPost]
        public IActionResult EditCategory(Category obj)
        {
            if (obj.DisplayOrder == 69)
            {
                ModelState.AddModelError("Name", "The number should not equal to 6ix9ine");
            }
            if (ModelState.IsValid)
            {

                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _db.categories.Where(u => u.Id == id).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();

            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteCategoryDELETE(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? obj = _db.categories.FirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
        }

    }
}