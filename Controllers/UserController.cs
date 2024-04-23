using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Microsoft.AspNetCore.Authentication;

namespace Assignment1.Controllers
{
    public class UserController : Controller
    {
        public UserTable userTable1 = new UserTable();

        [HttpPost]
        public ActionResult About(UserTable Users)
        {
           var result =  userTable1.insert_User(Users);
            return RedirectToAction("Privacy", "Home");
        }

        [HttpPost]
        public ActionResult about()
        {
            return View(userTable1);
        }
    }
}
