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
        ProductForViewVm GetProductDetails(int productId);

        ListOfProductsVm GetAllProducts();

        bool AddNewProduct(ProductForCreationVm product);

        ProductForViewVm GetProductById(int productId);

        void UpdateProduct(ProductForViewVm productModel);

        void DeleteProduct(int productId);

        void AddIngredientToProduct(int productId, int ingredientId);

        void DeleteIngredient(int productId, int ingredientId);

        void ChangeDietInformation(int productId, DietInfoForViewVm dietInformation);

        ListOfIngredientsVm GetAllIngredients();

        bool AddNewIngredient(IngredientForCreationVm ingredient);
        
        bool AddNewAllergen(AllergenForViewVm allergen);

        void AddNewImageToProduct(IFormFile image, int productId);

        void DeleteImageFromProduct(int productId);

        void AddDietInformationToProduct(string imageName, int productId);

        void DeleteTagFromDietInformation(int tagId, int dietInfoId);
    }
}
