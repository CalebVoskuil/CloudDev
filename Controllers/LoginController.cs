using Microsoft.AspNetCore.Mvc;
using Assignment1.Models;

namespace Assignment1.Controllers
{ 
    public class LoginController : Controller
    {
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Privacy(string password, string name)
        {
            var LoginModel = new LoginModel();
            int userID = LoginModel.select_User(password, name);
            if (userID != -1)
            { 
                HttpContext.Session.SetInt32("UserID", userID);
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return View("Login Failed");
            }
        }
    }
        


}
