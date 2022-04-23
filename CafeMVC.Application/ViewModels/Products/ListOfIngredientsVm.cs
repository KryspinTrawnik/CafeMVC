﻿using System.Collections.Generic;

namespace CafeMVC.Application.ViewModels.Products
{
    public class ListOfIngredientsVm
    {
        public List<IngredientForViewVm> Ingredients { get; set; }
        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public string SearchString { get; set; }

        public int Count { get; set; }
    }
}
