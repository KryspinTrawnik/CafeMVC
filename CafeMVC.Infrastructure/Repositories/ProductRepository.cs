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

        public void InsertAllergenToProduct(Allergen allergen, int productId)
        {
            Product updatedProduct = GetItemById(productId);
            updatedProduct.Allergens.Add(allergen);
            UpdateItem(updatedProduct);
        }

        public void InsertIngredientToProduct(Ingredient ingredient, int productId)
        {

            Product updatedProduct = GetItemById(productId);
            updatedProduct.Ingredients.Add(ingredient);
            UpdateItem(updatedProduct);
        }

        public IQueryable<Allergen> GetAllAllergensFromProduct(int productId)
        {
            
            return GetItemById(productId).Allergens.AsQueryable();
        }

        public IQueryable<Ingredient> GetAllIngredientsFromProduct(int productId)
        {
            
            return GetItemById(productId).Ingredients.AsQueryable();
        }

        public IQueryable<Ingredient>GetAllIngredients()
        {
            return _context.Ingredients;
        }


        public IQueryable<Allergen>GetAllAllergens()
        {
            return _context.Allergens;
        }

       
    }
}
