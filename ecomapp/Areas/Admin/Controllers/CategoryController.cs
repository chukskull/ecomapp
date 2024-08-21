using ecomapp.DataAccess.Data;
using ecomapp.DataAccess.Repository.IRepository;
using ecomapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ecomapp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CategoryController(IUnitOfWork db)
        {
            _UnitOfWork = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _UnitOfWork.category.GetAll().ToList();
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

                _UnitOfWork.category.Add(obj);
                _UnitOfWork.Save();
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
            // Category? ctg = _db.categories.Where(u => u.Id == id).FirstOrDefault();
            Category? ctg = _UnitOfWork.category.Get(u => u.Id == id);

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

                _UnitOfWork.category.Update(obj);
                _UnitOfWork.Save();
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
            Category? obj = _UnitOfWork.category.Get(u => u.Id == id);
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
            Category? obj = _UnitOfWork.category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _UnitOfWork.category.Remove(obj);
            _UnitOfWork.Save();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
        }

    }
}