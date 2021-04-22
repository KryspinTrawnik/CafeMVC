using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Domain.Interfaces
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        void AddNewProduct(Product product, Menu menu);

        IQueryable<Product> GetAllProduct(Menu menu);

        void DeleteProductFromMenu(int ProductId);
    }
}