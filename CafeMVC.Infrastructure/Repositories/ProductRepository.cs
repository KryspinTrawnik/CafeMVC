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

        public void AddAllergenToProduct(int allergenId, int productId)
        {
            var product = GetItemById(productId);
            product.Allergens.Add(GetAllergenById(allergenId));
            UpdateItem(product);
        }

        public void AddIngredientToProduct(int ingredientId, int productId)
        {
            var product = GetItemById(productId);
            product.Ingredients.Add(GetIngredientById(ingredientId));
            UpdateItem(product);
            Save();
        }

        public IQueryable<Allergen> GetAllAllergensFromProduct(int productId)
        {
            return GetItemById(productId).Allergens.AsQueryable();
        }

        public IQueryable<Ingredient> GetAllProductIngredients(int productId)
        {
            return GetItemById(productId).Ingredients.AsQueryable();
        }

        public void DeleteImageFromProduct(int productId)
        {
            Product product = GetItemById(productId);
            product.ImagePath = null;
            UpdateItem(product);
        }

        public void AddNewImageToProduct(string imageName, int productId)
        {
            Product product = GetItemById(productId);
            product.ImagePath = imageName;
            UpdateItem(product);
        }

        public void RemoveIngredientFromProduct(int ingredientId, int productId)
        {
            Product product = GetItemById(productId);
            product.Ingredients.Remove(GetIngredientById(ingredientId));
            UpdateItem(product);
        }


        public void RemoveAllergenFromProduct(int allergenId, int productId)
        {
            GetItemById(productId).Allergens.Remove(GetAllergenById(allergenId));
            Save();
        }

        public Ingredient GetIngredientById(int ingredientId) => _context.Ingredients.Find(ingredientId);

        public IQueryable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients;
        }

        public void AddNewIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            Save();
        }

        public Allergen GetAllergenById(int id)
        {
            return _context.Allergens.Find(id);
        }

        public IQueryable<Allergen> GetAllAllergens()
        {
            return _context.Allergens;
        }

        public void DeleteIngredient(int ingredientId)
        {
            _context.Ingredients.Remove(GetIngredientById(ingredientId));
            Save();
        }

        public void AddNewAllergen(Allergen allergen)
        {
            _context.Allergens.Add(allergen);
            Save();
        }

        public void AddDietInfoToProduct(DietInformation dietInfo, int productId)
        {
            GetItemById(productId).DietInformation.Add(dietInfo);
        }

        public IQueryable<DietInformation> GetAllDietInfo()
        {
            return _context.DietInformations.AsQueryable();
        }

        public IQueryable<DietInformation> GetAllProductDietInfo(int productId)
        {
            return GetItemById(productId).DietInformation.AsQueryable();
        }

        public void RemoveDietInfoFromProduct(int dietInfoId, int productId)
        {
            GetItemById(productId).DietInformation.Remove(_context.DietInformations.Find(dietInfoId));
            Save();
        }
    }
}
