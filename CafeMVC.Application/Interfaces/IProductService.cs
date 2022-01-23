using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Interfaces
{
    public interface IProductService
    {
        ListOfProductsVm GetAllProducts(int pageSize, int pageNo, string searchString);

        void AddNewProduct(ProductForCreationVm product);

        ProductForViewVm GetProductForViewById(int productId);

        ProductForCreationVm GetProductForCreationById(int productId);
        
        void AddAllergenToProduct(int productId, int allergenId);

        void UpdateProduct(ProductForCreationVm productModel);

        void DeleteProduct(int productId);

        void AddIngredientToProduct(int productId, int ingredientId);

        void DeleteIngredient(int productId, int ingredientId);

        ListOfIngredientsVm GetAllIngredients();

        void AddNewIngredient(IngredientForCreationVm ingredient);

        void AddNewAllergen(AllergenForViewVm allergen);

        void AddNewImageToProduct(IFormFile image, int productId);

        void DeleteImageFromProduct(int productId);

        void AddDietInfoToProduct(int dietInfoId, int productId);

        void DeleteDietInfoFromProduct(int dietInfoId, int productId);
    }
}
