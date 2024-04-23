using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {
        public ProductTable productTable1 = new ProductTable();

        [HttpPost]
        public ActionResult MyWork(ProductTable Products)
        {
            var result = productTable1.insert_Product(Products);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult MyWork()
        {
            return View(productTable1);
        }
    }
}
