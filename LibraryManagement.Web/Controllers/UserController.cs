using LibraryManagement.Business.IService;
using LibraryManagement.Business.Model;
using LibraryManagement.Business.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LibraryManagement.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        [HttpGet]
        public IActionResult Registration_form()
        {
            UserModel model = new UserModel();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult SaveUser(UserModel userModel)
        {
            bool result = userService.AddUser(userModel);

            if (result)
            {
                TempData["Message"] = "Registration Successfully Done";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Message"] = "Registration Failed";
                return RedirectToAction("Registration_form", "User");
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            UserModel model = new UserModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {
            var result = userService.login(userModel);

            if (result!=null && result.USER_ID>0)
            {
                HttpContext.Session.SetString("UserEmail", result.USER_EMAIL.ToString());
                HttpContext.Session.SetString("UserID", result.USER_ID.ToString());

                return RedirectToAction("HomePage","Book");
            }
            else
            {
                TempData["Message"] = "The user name or password are incorrect!";
                return RedirectToAction("Login");
            }

        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }

    }
}
