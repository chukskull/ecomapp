using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ecomapp.Models;

namespace ecomapp.Controllers;

public class HomeController : Controller
{


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}



public class SchoolController : Controller
{

    private readonly ILogger<SchoolController> _logger;

    public SchoolController(ILogger<SchoolController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult EtageOne()
    {
        return View();
    }

    public IActionResult EtageTwo()
    {
        return View();
    }


}