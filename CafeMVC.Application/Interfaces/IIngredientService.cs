﻿using CafeMVC.Application.ViewModels.Products;

namespace CafeMVC.Application.Interfaces
{
    public interface IIngredientService
    {
        void DeleteIngredient(int productId, int ingredientId);

        ListOfIngredientsVm GetAllIngredients();

        void AddNewIngredient(IngredientForCreationVm ingredient);

        void AddIngredientToProduct(int productId, int ingredientId);
    }
}
