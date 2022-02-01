using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IMenuRepository
    {
        IQueryable<Menu> GetAllActiveMenus();

        void AddNewProduct(Product product, int menuId);

        int AddNewMenu(Menu menu);

        IQueryable<Product> GetAllProduct(int menuId);

        void DeleteProductFromMenu(int menuId, int productId);

        Menu GetMenuByDietInformation(int menuId, DietInfoTag dietInformation);

        Menu GetMenuById(int menuId);

        void UpdateMenu(Menu menu);

        void DeleteMenu(int menuId);
    }
}