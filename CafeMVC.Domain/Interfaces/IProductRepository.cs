using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void InsertIngredientToProduct(Ingredient ingredient, int productId);

        IQueryable<Ingredient> GetAllIngredientsFromProduct(int productId);

        void InsertAllergenToProduct(Allergen allergen, int productId);

        IQueryable<Allergen> GetAllAllergensFromProduct(int productId);

        IQueryable<Allergen> GetAllAllergens();

        IQueryable<Ingredient> GetAllIngredients();
    }
}
