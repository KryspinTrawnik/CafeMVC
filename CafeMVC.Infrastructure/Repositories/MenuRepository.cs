using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Infrastructure.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(Context context) : base(context)
        {
        }

        public void AddNewProduct(Product product, int menuId)
        {
            var menu = GetItemById(menuId);
            menu.Products.Add(product);
            UpdateItem(menu);
        }

        public void DeleteProductFromMenu(int menuId, int productId)
        {
            var menu = GetItemById(menuId);
            menu.Products.Remove(menu.Products.ToList().Find(x => x.Id == productId));
        }

        public IQueryable<Product> GetAllProduct(int menuId)
        {

            return GetItemById(menuId).Products.AsQueryable<Product>();
        }
    }
}
