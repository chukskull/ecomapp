using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ecomapp.DataAccess.Repository.IRepository;
using ecomapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ecomapp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public ProductController(IUnitOfWork db)
        {
            _UnitOfWork = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _UnitOfWork.product.GetAll().ToList();

            return View(products);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]

        public IActionResult CreateProduct(Product obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.product.Add(obj);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult EditProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product product = _UnitOfWork.product.Get(u => u.Id == id);

            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product prd)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.product.Update(prd);
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

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