using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void DeleteImageFromProduct(int productId);
        
        void AddNewImageToProduct(string imageName, int productId);

        void InsertIngredientToProduct(int ingredientId, int productId);

        void RemoveIngredientFromProduct(int ingredientId, int productId);

        IQueryable<Ingredient> GetAllIngredientsFromProduct(int productId);

        void InsertAllergenToProduct(int allergenId, int productId);

        void RemoveAllergenFromProduct(int allergenId, int productId);

        IQueryable<Allergen> GetAllAllergensFromProduct(int productId);
        
        Ingredient GetIngredientById(int ingredientId);

        IQueryable<Ingredient> GetAllIngredients();

        void AddNewIngredient(Ingredient ingredient);

        void DeleteIngredient(int ingredietnId);

        void AddNewAllergen(Allergen allergen);
        
        IQueryable<Allergen> GetAllAllergens();

        Allergen GetAllergenById(int allergenId);

        void AddNewTagToDietInformation(DietInfoTag dietInfoTag, int productId);

        void DeleteTagFromDietInformation(string tagName, int productId);
    }
}
