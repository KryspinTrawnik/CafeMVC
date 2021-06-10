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

        public void InsertAllergenToProduct(int allergenId, int productId)
        {
            var product = GetItemById(productId);
            product.Allergens.Add(GetAllergenById(allergenId));
            UpdateItem(product);
        }

        public void InsertIngredientToProduct(int ingredientId, int productId)
        {
            var product = GetItemById(productId);
            product.Ingredients.Add(GetIngredientById(ingredientId));
            UpdateItem(product);
        }

        public IQueryable<Allergen> GetAllAllergensFromProduct(int productId)
        {
            return GetItemById(productId).Allergens.AsQueryable();
        }

        public IQueryable<Ingredient> GetAllIngredientsFromProduct(int productId)
        {
            return GetItemById(productId).Ingredients.AsQueryable();
        }

        public void DeleteImageFromProduct(int productId)
        {
            GetItemById(productId).ImageName = null;
        }

        public void AddNewImageToProduct(byte image, int productId)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveIngredientFromProduct(int ingredientId, int productId)
        {
            throw new System.NotImplementedException();
        }


        public void RemoveAllergenFromProduct(int allergenId, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Ingredient GetIngredientById(int ingredientId) => _context.Ingredients.Find(ingredientId);

        public IQueryable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients;
        }

        public void AddNewIngredient(Ingredient ingredient)
        {
            throw new System.NotImplementedException();
        }

        public Allergen GetAllergenById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Allergen> GetAllAllergens()
        {
            return _context.Allergens;
        }

        public void DeleteIngredient(int ingredietnId)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewAllergen(Allergen allergen)
        {
            throw new System.NotImplementedException();
        }


        public void AddNewTagToDietInformation(byte tag, int dietInfoId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTagFromDietInformation(int tagId, int dietInfoId)
        {
            throw new System.NotImplementedException();
        }

    }
}
