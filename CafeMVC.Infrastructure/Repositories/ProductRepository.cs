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
            _context.SaveChanges();
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
            _context.SaveChanges();
        }

        public void AddNewImageToProduct(string imageName, int productId)
        {
            GetItemById(productId).ImageName = imageName;
            _context.SaveChanges();
        }

        public void RemoveIngredientFromProduct(int ingredientId, int productId)
        {
            GetItemById(productId).Ingredients.Remove(GetIngredientById(ingredientId));
            _context.SaveChanges();
        }


        public void RemoveAllergenFromProduct(int allergenId, int productId)
        {
            GetItemById(productId).Allergens.Remove(GetAllergenById(allergenId));
            _context.SaveChanges();
        }

        public Ingredient GetIngredientById(int ingredientId) => _context.Ingredients.Find(ingredientId);

        public IQueryable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients;
        }

        public void AddNewIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
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
            _context.SaveChanges();
        }

        public void AddNewAllergen(Allergen allergen)
        {
            _context.Allergens.Add(allergen);
            _context.SaveChanges();
        }


        public void AddNewTagToDietInformation(DietInfoTag dietInfoTag, int productId)
        {
            GetItemById(productId).DietInformation.ListOfTagName.Add(dietInfoTag);
            _context.SaveChanges();
        }

        public void DeleteTagFromDietInformation(string tagName, int productId)
        {
            var tagToRemove = GetItemById(productId).DietInformation.ListOfTagName.FirstOrDefault(x => x.TagName == tagName);
            GetItemById(productId).DietInformation.ListOfTagName.Remove(tagToRemove);
            _context.SaveChanges();
        }

    }
}
