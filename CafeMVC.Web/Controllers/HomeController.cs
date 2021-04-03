using CafeMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CafeMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Menu()
        {
            ViewData["Złoty"] = "zł";
            var sniadania = new Menu() { Id = 1, Name = "Śniadania" };
            sniadania.ListOfProducts.Add(new Product { Id = 1, Name = "Owsianka", Price = 10 });
            sniadania.ListOfProducts.Add(new Product { Id = 2, Name = "Granola i owoce w Jogurcie", Price = 10 });
            sniadania.ListOfProducts.Add(new Product { Id = 3, Name = "Tost z szynką i serem", Price = 12 });
            
            return View(sniadania.ListOfProducts);
        }
        public IActionResult ProductView(int id)
        {
            ViewBag.Space = ", ";
            var sniadania = new Menu() { Id = 1, Name = "Śniadania" };
            sniadania.ListOfProducts = new List<Product>();
            var owsianka = new Product { Id = 1, Name = "Owsianka", Price = 10 };
            owsianka.Ingredients = new List<Ingredient>
            {
                new Ingredient {Id = 1, Name = "Płatki owsiane"},
                new Ingredient {Id = 2, Name = "Mleko"},
                new Ingredient {Id = 3, Name = "Banan"},
                new Ingredient {Id = 4, Name = "Truskawki"}
            };
            sniadania.ListOfProducts.Add(owsianka);
            return View(sniadania.ListOfProducts[id-1]);
        }
        public IActionResult OrderView()
        {
            var orderView = new OrderView();
            orderView.MenuList.Add(new Menu { Id = 1, Name = "Śniadania" });
            orderView.MenuList.Add(new Menu { Id = 2, Name = "Bajglo-Burgery" });
            orderView.MenuList.Add(new Menu { Id = 3, Name = "Naleśniki" });
            orderView.MenuList.Add(new Menu { Id = 4, Name = "Napoje Gorące" });
            return View(orderView);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
