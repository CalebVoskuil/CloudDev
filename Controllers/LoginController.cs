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
        public ActionResult Privacy(string Password, string name)
        {
            var LoginModel = new LoginModel();
            int userID = LoginModel.select_User(Password, name);
            if (userID != -1)
            { 
                HttpContext.Session.SetInt32("UserID", userID);
                return RedirectToAction("About");
            }
            else
            {
                return View("Login Failed");
            }
        }
    }
        


}
