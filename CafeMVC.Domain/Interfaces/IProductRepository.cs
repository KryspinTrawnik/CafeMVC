using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void AddNewIngredient();

        IQueryable<Ingredient> GetAllIngredients(Product product);

        void AddNewAllergen();

        IQueryable<Allergen> GetAllAllergens(Product product);


    }
}
