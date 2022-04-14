using CafeMVC.Application.ViewModels.Products;
using Microsoft.AspNetCore.Http;

namespace CafeMVC.Application.Interfaces
{
    public interface IProductService
    {
        ListOfProductsVm GetAllProducts(int pageSize, int pageNo, string searchString);

        void AddNewProduct(ProductForCreationVm product);

        ProductForViewVm GetProductForViewById(int productId);

        ProductForEditionVm GetProductForEdtitionById(int productId);

        void UpdateProduct(ProductForEditionVm productModel);

        void DeleteProduct(int productId);

        void DeleteImageFromProduct(int productId);

        void AddDietInfoToProduct(int dietInfoId, int productId);

        void DeleteDietInfoFromProduct(int dietInfoId, int productId);

        ProductForCreationVm GetProductForCreation();
    }
}
