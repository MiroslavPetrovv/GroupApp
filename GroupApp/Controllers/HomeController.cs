using GroupApp.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GroupApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {     
            return RedirectToAction("Index", "Group");
        }


    }
}
