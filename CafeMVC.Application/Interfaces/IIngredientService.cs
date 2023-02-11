using CafeMVC.Application.ViewModels.Customer;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Model;
using System.Collections.Generic;

namespace CafeMVC.Application.Interfaces
{
    public interface IIngredientService
    {
        void DeleteIngredient( int ingredientId);

        ListOfIngredientsVm GetListIngredientsForEdition(int pageSize, int pageNo, string searchString);

        List<IngredientForViewVm> GetAllIngredients();
    
        void AddNewIngredient(IngredientForViewVm ingredient);

        List<IngredientForViewVm> GetProductAllIngredients(int productId);

        void UpdateProductIngredientTable(int productId, List<ProductIngredient> productIngredients);
        
        IngredientForViewVm GetIngredientById(int ingredientId);
   
        void ChangeIngredient(IngredientForViewVm editedIngredient);
       
    }
}
