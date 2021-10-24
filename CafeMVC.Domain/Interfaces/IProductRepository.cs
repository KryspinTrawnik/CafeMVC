using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IProductRepository 
    {
        int AddNewProduct(Product product);

        void DeleteImageFromProduct(int productId);
        
        void AddNewImageToProduct(string imageName, int productId);

        void AddIngredientToProduct(int ingredientId, int productId);

        void RemoveIngredientFromProduct(int ingredientId, int productId);

        IQueryable<Ingredient> GetAllProductIngredients(int productId);

        void AddAllergenToProduct(int allergenId, int productId);

        void RemoveAllergenFromProduct(int allergenId, int productId);

        IQueryable<Allergen> GetAllAllergensFromProduct(int productId);
        
        Ingredient GetIngredientById(int ingredientId);

        IQueryable<Ingredient> GetAllIngredients();

        void AddNewIngredient(Ingredient ingredient);

        void DeleteIngredient(int ingredietnId);

        void AddNewAllergen(Allergen allergen);
        
        IQueryable<Allergen> GetAllAllergens();

        Allergen GetAllergenById(int allergenId);

        IQueryable<DietInformation> GetAllDietInfo();

        IQueryable<DietInformation> GetAllProductDietInfo(int productId);

        void RemoveDietInfoFromProduct(int dietInfoId, int productId);

        Product GetProductById(int productId);

        void UpdateProduct(Product product);

        void AddDietInfoToProduct(int dietInfoId, int productId);

    }
}
