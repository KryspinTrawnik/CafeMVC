using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }

        public void AddNewAllergen()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewIngredient()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Allergen> GetAllAllergens(Product product)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Ingredient> GetAllIngredients(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
