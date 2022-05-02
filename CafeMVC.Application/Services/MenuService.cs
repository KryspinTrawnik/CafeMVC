using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.ViewModels.Menu;
using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Interfaces;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeMVC.Application.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IMapper mapper, IProductRepository productRepository, IProductService productService)
        {
            _productRepository = productRepository;
            _menuRepository = menuRepository;
            _productService = productService;
            _mapper = mapper;
        }

        private void AddListOfProducts(List<int> productsIds, int newMenuId)
        {
            for(int i = 0; i < productsIds.Count; i++)
            {
                Product product = _productRepository.GetProductById(productsIds[i]);
                product.MenuId = newMenuId;
                _productRepository.UpdateProduct(product);
            }
        }

        public void AddNewMenu(MenuForCreationVm menuModel)
        {
            Menu menu = _mapper.Map<Menu>(menuModel);
            int newMenuId = _menuRepository.AddNewMenu(menu);
            AddListOfProducts(menuModel.ProductsIds, newMenuId);
          
        }

        public void AddProductToMenu(int productId, int menuId)
        {
            Menu menu = _menuRepository.GetMenuById(menuId);
            if(menu != null)
            {
                menu.Products.Add(_productRepository.GetProductById(productId));
                _menuRepository.UpdateMenu(menu);
            }
        }

        public void ChangeMenu(MenuForViewVm menuModel)
        {
            Menu menu = _mapper.Map<Menu>(menuModel);
            _menuRepository.UpdateMenu(menu);
        }

        public void DeleteMenu(int menuId)=>_menuRepository.DeleteMenu(menuId);
        
        public void DeleteProductFromMenu(int productId, int menuId)
        {
            Product prodtuctToRemove = _productRepository.GetProductById(productId);
            _menuRepository.GetMenuById(menuId).Products.Remove(prodtuctToRemove);
        }

        public ListOfMenusVm GetAllMenus(int pageSize, int pageNo, string searchString)
        {
            List<MenuForListVm> allMenus = _menuRepository.GetAllActiveMenus().Where(x => x.Name.StartsWith(searchString))
                .ProjectTo<MenuForListVm>(_mapper.ConfigurationProvider)
                .Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            return new()
            {
                ListOfAllMenus = allMenus,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = allMenus.Count
            };
        }

        public MenuForViewVm GetAllProducstOfMenu(int menuId)=>_mapper.Map<MenuForViewVm>(_menuRepository.GetMenuById(menuId));

        public MenuForViewVm GetProductsByDieteInfo(DietInfoForViewVm dieteInfoVm, int menuTypeId)
        {
            DietInfoTag dietInfo = _mapper.Map<DietInfoTag>(dieteInfoVm);
            Menu menu = _menuRepository.GetMenuByDietInformation(menuTypeId, dietInfo);
            
            return _mapper.Map<MenuForViewVm>(menu); 
        }

        public MenuForCreationVm GetMenuForCreation()=>new(){ AllProducts = _productRepository.GetAllProducts()
            .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList() };

        public MenuForViewVm GetMenuForView(int manuId)
        {
            Menu menu = _menuRepository.GetMenuById(manuId);

            return _mapper.Map<MenuForViewVm>(menu);
        }
    }
}
