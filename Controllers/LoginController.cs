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
        public ActionResult Privacy(string email, string name)
        {
            var LoginModel = new LoginModel();
            int userID = LoginModel.select_User(email, name);
            if (userID != -1)
            {
                return RedirectToAction("Privacy", "Home", new {userID = userID});
            }
            else
            {
                return View("Login Failed");
            }
        }
    }
        


}
