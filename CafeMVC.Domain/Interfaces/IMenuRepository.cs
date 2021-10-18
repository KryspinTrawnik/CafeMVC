using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Interfaces
{
    public interface IMenuRepository 
    {
        void AddNewProduct(Product product, int menuId);

        IQueryable<Product> GetAllProduct(int menuId);

        void DeleteProductFromMenu(int menuId, int productId);

        Menu GetMenuByDietInformation(int menuId, DietInformation dietInformation);
    }
}