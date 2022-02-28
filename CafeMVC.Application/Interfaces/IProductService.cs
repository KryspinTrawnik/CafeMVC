using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;

namespace CafeMVC.Application.Interfaces
{
    public interface IProductService
    {
        ListOfProductsVm GetAllProducts(int pageSize, int pageNo, string searchString);

        void AddNewProduct(ProductForCreationVm product);

        ProductForViewVm GetProductForViewById(int productId);

        ProductForCreationVm GetProductForEdtitionById(int productId);

        void UpdateProduct(ProductForCreationVm productModel);

        void DeleteProduct(int productId);

        void AddNewImageToProduct(IFormFile image, int productId);
        
        void DeleteImageFromProduct(int productId);

        void AddDietInfoToProduct(int dietInfoId, int productId);

        void DeleteDietInfoFromProduct(int dietInfoId, int productId);

        ProductForCreationVm GetProductForCreation();
    }
}
