using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CafeMVC.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var ListOfMenus = _menuService.GetMenusToDisplay(20, 1, "");

            return View(ListOfMenus);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = string.Empty;
            }
            pageSize = 20;
            var ListOfMenus = _menuService.GetMenusToDisplay(pageSize, pageNo.Value, searchString);

            return View(ListOfMenus);
        }

        [HttpGet]
        public IActionResult ViewMenu(int menuId)
        {
            MenuForViewVm menuForView = _menuService.GetMenuForView(menuId);

            return View(menuForView);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddNewMenu()
        {
            return View(_menuService.GetMenuForCreation());
        }

        [HttpPost]
        public IActionResult AddNewMenu(MenuForCreationVm menuModel)
        {
            if (menuModel.Btn == "Submit")
            {
                _menuService.AddNewMenu(menuModel);
            }

            return RedirectToAction("index");
        }

        public IActionResult DeleteMenu(int menuId)
        {
            _menuService.DeleteMenu(menuId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditMenu(int menuId)
        {
            MenuForCreationVm menu = _menuService.GetMenuForEdition(menuId);

            return View(menu);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditMenu(MenuForCreationVm menuModel)
        {
            if (menuModel.Btn == "Submit")
            {
                _menuService.ChangeMenu(menuModel);
            }

            return RedirectToAction("index");
        }

        public ActionResult DropDownMenus()
        {

            List<MenuForListVm> openMenus = _menuService.GetPublicMenus();

            return PartialView("DropDownMenus", openMenus);
        }
    }
}
