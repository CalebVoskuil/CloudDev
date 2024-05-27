using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class ProductController : Controller
    {
        public ProductTable productTable1 = new ProductTable();

        [HttpPost]
        public ActionResult MyWork(ProductTable products)
        {
            var result = productTable1.insert_Product(products);
            return RedirectToAction("MyWork");
            
        }

        [HttpPost]
        public ActionResult MyWork()
        {
            
            return View(productTable1);
        }
    }
}
