using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Model;
using System.Collections.Generic;

namespace CafeMVC.Application.Interfaces
{
    public interface IIngredientService
    {
        void DeleteIngredient(int productId, int ingredientId);

        List<IngredientForViewVm> GetAllIngredients();
    
        void AddIngredientToProduct(int productId, int ingredientId);
        
        void AddNewIngredient(IngredientForViewVm ingredient);

        List<IngredientForViewVm> GetProductAllIngredients(int productId);

        void UpdateProductIngredientTable(int productId, List<ProductIngredient> productIngredients);
    }
}
