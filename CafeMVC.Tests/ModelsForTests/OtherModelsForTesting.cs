//using CafeMVC.Domain.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CafeMVC.Tests
//{
//    public class OtherModelsForTesting
//    {
//        public Menu GetBajgleMenu()
//        {
//            var productsForMenu = new ProductsForTesting();
//            var bajgleMenu = new Menu()
//            { Id = 1, Name = "Bajgle", Products = productsForMenu.GetProductsForBajgleMenu() };
//            return bajgleMenu;
//        }
//        public Menu GetNalesnikiMenu()
//        {
//            var productsForMenu = new ProductsForTesting();
//            var nalesnikiMenu = new Menu()
//            { Id = 2, Name = "Nalesnik", Products = productsForMenu.GetProductsForNalesnikiMenu() };
//            return nalesnikiMenu;
//        }
//        public List<Menu> GetAllMenus()
//        {
//            var allMenus = new List<Menu>()
//            {  
//                GetBajgleMenu(),
//                GetNalesnikiMenu()
//            };
//            return allMenus;
//        }

//        public List<Ingredient> GetAllIngredients()
//        {
//            var allIngredients = new List<Ingredient>()
//            {
//               new Ingredient{Id = 1, Name = "Bajgiel"},
//               new Ingredient{Id = 2, Name = "Wołowina"},
//               new Ingredient{Id = 3, Name = "Mozarella"},
//               new Ingredient{Id = 4, Name = "Warzywa"},
//               new Ingredient{Id = 5, Name = "Kurczak"},
//               new Ingredient{Id = 6, Name = "Cebula prażona"},
//               new Ingredient{Id = 7, Name = "Camembert"},
//               new Ingredient{Id = 8, Name = "Żurawina"},
//               new Ingredient{Id = 9, Name = "Falafel"},
//               new Ingredient{Id = 10, Name = "Ogórek konserwowy"},
//               new Ingredient{Id = 11, Name = "dżem"},
//               new Ingredient{Id = 12, Name = "sos owocowy"},
//               new Ingredient{Id = 13, Name = "śmietana"},
//               new Ingredient{Id = 14, Name = "chorizo"},
//               new Ingredient{Id = 15, Name = "suszone pomidory"},
//               new Ingredient{Id = 16, Name = "Łosoś"},
//               new Ingredient{Id = 17, Name = "Szpinak"},
//               new Ingredient{Id = 18, Name = "Ser feta"},
//               new Ingredient{Id = 19, Name = "Kebab"},
//               new Ingredient{Id = 20, Name = "Papryka"},
//               new Ingredient{Id = 21, Name = "Kukurydza"},

//            };
//            return allIngredients;
//        }
//        public List<Allergen> GetAllAl()
//        {
//            var allAllergens = new List<Allergen>()
//            {
//                new Allergen {Id = 1, Name = "GLUTEN" },
//                new Allergen {Id = 2, Name ="SKORUPIAKI i produkty pochodne" },
//                new Allergen {Id = 3, Name ="JAJA i produkty pochodne"},
//                new Allergen {Id = 4, Name ="RYBY i produkty pochodne"},
//                new Allergen {Id = 5, Name ="ORZESZKI ZIEMNE (arachidowe) i produkty pochodne" },
//                new Allergen {Id = 6, Name ="SOJA i produkty pochodne"},
//                new Allergen {Id = 7, Name ="MLEKO i produkty pochodne (łącznie z laktozą)"},
//                new Allergen {Id = 8, Name ="ORZECHY"},
//                new Allergen {Id = 9, Name ="SELER i produkty pochodne"},
//                new Allergen {Id = 10, Name ="GORCZYCA i produkty pochodne"},
//                new Allergen {Id = 11, Name ="NASIONA SEZAMU i produkty pochodne"},
//                new Allergen {Id = 12, Name ="DWUTLENEK SIARKI"},
//                new Allergen {Id = 13, Name ="ŁUBIN i produkty pochodne"},
//                new Allergen {Id = 14, Name ="MIĘCZAKI i produkty pochodne"},
//            };
//            return allAllergens;
//        }


//    }
//}
