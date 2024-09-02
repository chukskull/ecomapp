
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ecomapp.DataAccess.Repository.IRepository;
using ecomapp.Models;
using ecomapp.Models.ModelsView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace ecomapp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _UnitOfWork.product.GetAll(includeProperties: "Category").ToList();


            return View(products);
        }

        public IActionResult UpSert(int? id)

        {

            // ViewBag.CategoryList = categories;
            ProductVM productVM = new ProductVM
            {

                CategoryList = _UnitOfWork.category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()

            };
            if (id != null && id != 0)
            {
                productVM.Product = _UnitOfWork.product.Get(u => u.Id == id);
                return View(productVM);
            }
            else
                return View(productVM);
        }
        [HttpPost]

        public IActionResult UpSert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {

                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string combine = Path.Combine(wwwRootPath, "images/product");

                    if (!string.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        if (System.IO.File.Exists(Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('/'))))
                        {
                            System.IO.File.Delete(Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('/')));
                        }
                    }
                    using (var FileStream = new FileStream(Path.Combine(string.Concat('/', combine), filename), FileMode.Create))
                    {
                        file.CopyTo(FileStream);
                    }
                    obj.Product.ImageUrl = "/images/product/" + filename;
                }
                if (obj.Product.Id == 0)
                    _UnitOfWork.product.Add(obj.Product);
                else
                    _UnitOfWork.product.Update(obj.Product);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _UnitOfWork.category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
            }
            return View();
        }

        // public IActionResult EditProduct(int? id)
        // {
        //     if (id == null || id == 0)
        //     {
        //         return NotFound();
        //     }
        //     Product product = _UnitOfWork.product.Get(u => u.Id == id);

        //     return View(product);
        // }
        // [HttpPost]
        // public IActionResult EditProduct(Product prd)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _UnitOfWork.product.Update(prd);
        //         _UnitOfWork.Save();
        //         return RedirectToAction("Index");
        //     }
        //     return NotFound();
        // }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product product = _UnitOfWork.product.Get(u => u.Id == id);

            return View(product);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? product = _UnitOfWork.product.Get(u => u.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _UnitOfWork.product.Remove(product);
            _UnitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}