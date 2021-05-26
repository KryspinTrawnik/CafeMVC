using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface IProductService
    {
        ProductForViewVm GetProductDetails(int productId);

        ListOfProductsVm GetAllProducts();

        void AddNewProduct(ProductForViewVm product);

        ProductForViewVm GetProductById(int productId);

        void UpdateProduct(ProductForViewVm productModel);

        void DeleteProduct(int productId);

        void AddIngredientToProduct(int productId, int ingredientId);

        void DeleteIngredient(int productId, int ingredientId);

        void ChangeDietInformation(int productId, DietInfoForViewVm dietInformation);

        ListOfIngredientsVm GetAllIngredients();

        void AddNewIngredient(IngredientForViewVm ingredient);
        
        void AddNewAllergen(AllergenForViewVm allergen);
    }
}
