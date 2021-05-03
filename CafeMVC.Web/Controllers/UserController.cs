using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // add user
        // add address
        // change address
        // view list of users
        
        [HttpGet]
        public IActionResult ViewUserDetails(int userId)
        {
            var userForView = userServiece.GetUserById(userId);
            return View(userModel);                  
        }
        [HttpGet]
        public IActionResult AddNewUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewUser(UserModel userModel)
        {
            userService.AddNewUser(userModel);
            return View()
        }
    }
}
