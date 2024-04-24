using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;
using Microsoft.AspNetCore.Authentication;

namespace Assignment1.Controllers
{
    public class UserController : Controller
    {
        public UserTable userTable1 = new UserTable();

        [HttpPost]
        public IActionResult SignUp(UserTable Users)
        {
           var result =  userTable1.insert_User(Users);
            return RedirectToAction("Privacy", "Home");
        }

        
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
