using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Services
{
    public class ProductService : IProductService
    {
        public void AddIngredientToProduct(int productId, int ingredientId)
        {
            throw new NotImplementedException();
        }

        public void AddNewAllergen(AllergenForViewVm allergen)
        {
            throw new NotImplementedException();
        }

        public void AddNewImageToProduct(byte image, int productId)
        {
            throw new NotImplementedException();
        }

        public void AddNewIngredient(IngredientForViewVm ingredient)
        {
            throw new NotImplementedException();
        }

        public void AddNewProduct(ProductForCreationVm product)
        {
            throw new NotImplementedException();
        }

        public void AddNewTagToDietInformation(string imageName, int dietInfoId)
        {
            throw new NotImplementedException();
        }

        public void ChangeDietInformation(int productId, DietInfoForViewVm dietInformation)
        {
            throw new NotImplementedException();
        }

        public void DeleteImageFromProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void DeleteIngredient(int productId, int ingredientId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTagFromDietInformation(int tagId, int dietInfoId)
        {
            throw new NotImplementedException();
        }

        public ListOfIngredientsVm GetAllIngredients()
        {
            throw new NotImplementedException();
        }

        public ListOfProductsVm GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public ProductForViewVm GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public ProductForViewVm GetProductDetails(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductForViewVm productModel)
        {
            throw new NotImplementedException();
        }
    }
}
