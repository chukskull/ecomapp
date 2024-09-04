using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ecomapp.Models;
using ecomapp.DataAccess.Repository;
using ecomapp.DataAccess.Repository.IRepository;






namespace ecomapp.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork db)
        {
            _logger = logger;
            unitOfWork = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = unitOfWork.product.GetAll(includeProperties: "Category");
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Details(int productId)
        {
            Product product = unitOfWork.product.Get(u => u.Id == productId);

            return View(product);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}




