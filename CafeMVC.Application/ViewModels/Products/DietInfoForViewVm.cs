﻿using AutoMapper;
using CafeMVC.Application.Interfaces.Mapping;

namespace CafeMVC.Application.ViewModels.Products
{
    public class DietInfoForViewVm : IMapFrom<CafeMVC.Domain.Model.DietInfoTag>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Pathway { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CafeMVC.Domain.Model.DietInfoTag, DietInfoForViewVm>();
        }
    }
}