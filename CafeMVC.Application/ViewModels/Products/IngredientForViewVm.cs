﻿using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Products
{
    public class IngredientForViewVm : IMapFrom<CafeMVC.Domain.Model.Ingredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.Ingredient, IngredientForViewVm>();
        }
    }
}