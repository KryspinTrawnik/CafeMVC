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
            
            return (IQueryable<Allergen>)GetItemById(productId).Allergens.ToList();
        }

        public IQueryable<Ingredient> GetAllIngredientsFromProduct(int productId)
        {
            
            return (IQueryable<Ingredient>)GetItemById(productId).Ingredients.ToList();
        }

        public IQueryable<Ingredient>GetAllIngredients()
        {
            return (IQueryable<Ingredient>)_context.Ingredients.ToList();
        }


        public IQueryable<Allergen>GetAllAllergens()
        {
            return (IQueryable<Allergen>)_context.Allergens.ToList();
        }

       
    }
}
