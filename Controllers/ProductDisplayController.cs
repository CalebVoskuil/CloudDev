using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class ProductDisplayController : Controller 
    {
        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductDisplayModel.select_Products();
            return View(products);
        }
    }
}
