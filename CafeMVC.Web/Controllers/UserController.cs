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
            var ListOfUsers = userService.GetAllUsers();
            return View(ListOfUsers);
        }
  
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
            return View();
        }
        [HttpGet]
        public IActionResult AddNewContactDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewContactDetail(ContactDetailForVM contactDetail, int userId)
        {
            userService.AddNewContactDetail(contactDetail, userId);
            return View();
        }

        [HttpGet]
        public IActionResult RemoveContactDetail()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult RemoveContactDetail(ContactDetailForVM contactDetail, int userId)
        {
            userService.RemoveContactDetail(contactDetail, userId);
            return View();
        }
        [HttpGet]
        public IActionResult AddNewAddress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAddress(AddressForVM address, int userId)
        {
            userService.AddNewAddress(address, userId);
            return View();
        }
        [HttpGet]
        public IActionResult ChangeAddress()
        {
            return View();
        }
        [HttpPatch]
        public IActionResult ChangeAddress(AddressModel address, int userId)
        {
            userService.ChangeUserAddress(address);
            return View();
        }
        [HttpGet]
        public IActionResult RemoveAddress()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult RemoveAddress(AddressModel address, int userId)
        {
            userService.RemoveAddress(address, userId);
            return View();
        }
    }
}
