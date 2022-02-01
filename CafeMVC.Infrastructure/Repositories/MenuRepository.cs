using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CafeMVC.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly Context _context;

        public MenuRepository(Context context)
        {
            _context = context;
        }

        public Menu GetMenuById(int menuId)
        {
            Menu menu = _context.Menus.AsNoTracking()
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == menuId);
            return menu;
        }
        public void UpdateMenu(Menu menu)
        {
            _context.Attach(menu);
            _context.Entry(menu).Property("Products");
            _context.Entry(menu).Property("Name");
            _context.SaveChanges();
        }
        public void AddNewProduct(Product product, int menuId)
        {
            var menu = GetMenuById(menuId);
            menu.Products.Add(product);
            UpdateMenu(menu);
        }

        public void DeleteProductFromMenu(int menuId, int productId)
        {
            var menu = GetMenuById(menuId);
            menu.Products.Remove(menu.Products.ToList().Find(x => x.Id == productId));
            UpdateMenu(menu);
        }

        public IQueryable<Product> GetAllProduct(int menuId)=>GetMenuById(menuId).Products.AsQueryable();

        public Menu GetMenuByDietInformation(int menuId, DietInfoTag dietInformation)
        {
            var menu = GetMenuById(menuId);
            menu.Products = menu.Products.Where(x => x.ProductDietInfoTags.Any(x => x.DietInfoTagId == dietInformation.Id) ).ToList();

            return menu;
        }

        public int AddNewMenu(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();

            return menu.Id;
        }

        public void DeleteMenu(int menuId)
        {
            var menu = _context.Menus.Find(menuId);
            menu.HasBeenRemoved = true;
            UpdateMenu(menu);
        }

        public IQueryable<Menu> GetAllActiveMenus()
        {
            var activeMenus = _context.Menus.AsNoTracking()
                .Include(x => x.Products)
                .Where(x => x.HasBeenRemoved == false);

            return activeMenus;
        }
    }
}
