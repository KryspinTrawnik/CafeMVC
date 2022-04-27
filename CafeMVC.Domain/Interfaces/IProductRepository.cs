using CafeMVC.Domain.Model;
using System.Linq;

namespace CafeMVC.Domain.Interfaces
{
    public interface IProductRepository
    {
            //*** Product Actions **\\
        Product GetProductById(int productId);

        int AddNewProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int productId);

        IQueryable<Product> GetAllProducts();

        //*** Ingredient Actions **\\
        void AddIngredientToProduct(ProductIngredient productIngredient);

        void RemoveIngredientFromProduct(ProductIngredient productIngredientToBeRemoved);

        IQueryable<ProductIngredient> GetAllProductIngredients(int productId);

        IQueryable<Ingredient> GetAllIngredients();
       
        Ingredient GetIngredientById(int ingredientId);

        void AddNewIngredient(Ingredient ingredient);

        void DeleteIngredient(int ingredietnId);

        //*** Allergen Actions **\\
        IQueryable<ProductAllergen> GetAllAllergensFromProduct(int productId);
       
        void AddAllergenToProduct(ProductAllergen productAllergen);

        void RemoveAllergenFromProduct(ProductAllergen productAllergenToBeRemoved);

        void AddNewAllergen(Allergen allergen);
        
        IQueryable<Allergen> GetAllAllergens();

        Allergen GetAllergenById(int allergenId);

        //*** Diet info Actions **\\

        void DeleteAllergen(int allergenId);
        
        IQueryable<DietInfoTag> GetAllDietInfo();

        IQueryable<ProductDietInfoTag> GetAllProductDietInfo(int productId);

        void RemoveDietInfoFromProduct(ProductDietInfoTag productDietInfoTagToBeRemoved);

        void AddDietInfoToProduct(ProductDietInfoTag productDietInfoTag);
    }
}
