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

            Menu menu = _context.Menus.AsNoTrackingWithIdentityResolution()
                .Include(x => x.Products).AsNoTracking()
                .FirstOrDefault(x => x.Id == menuId);

            return menu;
        }
        public void UpdateMenu(Menu menu)
        {
            _context.Entry(menu).Collection("Products").IsModified = true;
            _context.Entry(menu).Property("Name").IsModified = true;
            _context.Entry(menu).Property("HasBeenRemoved").IsModified = true;
            _context.SaveChanges();
        }
        public void AddProductToMenu(int menuId, int productId)
        {
           Product product= _context.Products.FirstOrDefault(x => x.Id == productId);
           product.MenuId = menuId;
            _context.Entry(product).Property("MenuId").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteProductFromMenu(int menuId, int productId)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == productId);
            product.MenuId = null;
            _context.Entry(product).Property("MenuId").IsModified = true;
            _context.SaveChanges();
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
            Menu menu = _context.Menus.FirstOrDefault(x => x.Id == menuId);
            if(menu != null)
            {
                _context.Menus.Remove(menu);
                _context.SaveChanges();
            }
        }

        public IQueryable<Menu> GetAllMenus()
        {
            var activeMenus = _context.Menus.AsNoTracking();
                
            return activeMenus;
        }
    }
}
