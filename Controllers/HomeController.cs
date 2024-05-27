using Assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger,IHttpContextAccessor httpContextAccessor )
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult MyWork()
        {
            List<ProductTable> products = ProductTable.GetAllProducts();
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            ViewData["products"] = products;
            ViewData["UserID"] = userID;
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
       


        public IActionResult Error()
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(model);
        }
    }
}
