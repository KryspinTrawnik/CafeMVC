using AutoMapper;
using AutoMapper.QueryableExtensions;
using CafeMVC.Application.Interfaces;
using CafeMVC.Application.Services.Helpers;
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
            _productRepository = productRepository ?? throw new ArgumentNullException();
            _menuRepository = menuRepository ?? throw new ArgumentNullException();
            _productService = productService ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        private List<Product> AddListOfProducts(List<int> productsIds)
        {
            List<Product> products = new();
            for (int i = 0; i < productsIds.Count; i++)
            {
                products.Add(_productRepository.GetProductById(productsIds[i]));
            }

            return products;
        }

        public void AddNewMenu(MenuForCreationVm menuModel)
        {
            Menu menu = _mapper.Map<Menu>(menuModel);
            menu.Products = AddListOfProducts(menuModel.ProductsIds);
            _menuRepository.AddNewMenu(menu);

        }

        public void AddProductToMenu(int productId, int menuId)
        {
            Menu menu = _menuRepository.GetMenuById(menuId);
            if (menu != null)
            {
                menu.Products.Add(_productRepository.GetProductById(productId));
                _menuRepository.UpdateMenu(menu);
            }
        }

        public void ChangeMenu(MenuForCreationVm menuModel)
        {
            Menu menu = _mapper.Map<Menu>(menuModel);

            UpdateMenuProducts(menu.Id, menuModel.ProductsIds);

            _menuRepository.UpdateMenu(menu);
        }

        private void UpdateMenuProducts(int menuid, List<int> productsIds)
        {
            if(productsIds != null)
            { 
            List<int> allProductsIdsFromMenu = _menuRepository.GetAllProduct(menuid).Select(x => x.Id).ToList();
            List<int> toBeRemoved = allProductsIdsFromMenu.Except(productsIds, new Helper()).ToList();
            if (toBeRemoved != null)
            {
                for (int i = 0; i < toBeRemoved.Count; i++)
                {
                    _menuRepository.DeleteProductFromMenu(menuid, toBeRemoved[i]);
                }
            }
            List<int> toBeAdded = productsIds.Except(_menuRepository.GetAllProduct(menuid).Select(x => x.Id).ToList(), new Helper()).ToList();
            if (toBeAdded != null)
            {
                for (int i = 0; i < toBeAdded.Count; i++)
                {
                    _menuRepository.AddProductToMenu(menuid, toBeAdded[i]);
                }
            }
            }
        }

        public void DeleteMenu(int menuId) => _menuRepository.DeleteMenu(menuId);
        
        public void DeleteProductFromMenu(int productId, int menuId)
        {
            Product prodtuctToRemove = _productRepository.GetProductById(productId);
            _menuRepository.GetMenuById(menuId).Products.Remove(prodtuctToRemove);
           
        }

        public ListOfMenusVm GetMenusToDisplay(int pageSize, int pageNo, string searchString)
        {
            List<MenuForListVm> menus = _menuRepository.GetAllMenus().Where(x => x.Name.StartsWith(searchString))
                .ProjectTo<MenuForListVm>(_mapper.ConfigurationProvider).ToList();
            List<MenuForListVm> menusToDisplay = menus.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

            return new()
            {
                ListOfAllMenus = menusToDisplay,
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Count = menus.Count
            };
        }

        public MenuForViewVm GetAllProducstOfMenu(int menuId) => _mapper.Map<MenuForViewVm>(_menuRepository.GetMenuById(menuId));

        public MenuForViewVm GetProductsByDieteInfo(DietInfoForViewVm dieteInfoVm, int menuTypeId)
        {
            DietInfoTag dietInfo = _mapper.Map<DietInfoTag>(dieteInfoVm);
            Menu menu = _menuRepository.GetMenuByDietInformation(menuTypeId, dietInfo);

            return _mapper.Map<MenuForViewVm>(menu);
        }

        public MenuForCreationVm GetMenuForCreation() => new()
        {
            AllProducts = _productRepository.GetAllProducts().Where(x => x.MenuId == null)
            .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList()
        };

        public MenuForViewVm GetMenuForView(int manuId)
        {
            Menu menu = _menuRepository.GetMenuById(manuId);
            MenuForViewVm menuForView = _mapper.Map<MenuForViewVm>(menu);
            for (int i = 0; i < menuForView.Products.Count; i++ )
            {
                var productForView = _productService.GetProductForViewById(menuForView.Products[i].Id);
                menuForView.Products[i] = productForView;
            }

            return menuForView;
        }

        public MenuForCreationVm GetMenuForEdition(int menuId)
        {
            Menu menu = _menuRepository.GetMenuById(menuId);
            MenuForCreationVm menuForEdition = _mapper.Map<MenuForCreationVm>(menu);
            menuForEdition.AllProducts = _productRepository.GetAllProducts().Where(x => x.MenuId == null)
                .ProjectTo<ProductForListVm>(_mapper.ConfigurationProvider).ToList();

            return menuForEdition;
        }
    }
}
