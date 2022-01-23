//using CafeMVC.Domain.Model;
//using System.Collections.Generic;

//namespace CafeMVC.Tests
//{
//    public class ProductsForTesting
//    {
//        public List<Product> GetProductsForBajgleMenu()
//        {
//            Product product1 = new Product()
//            {
//                Id = 1,
//                Name = "Bajgiel Burger",
//                Price = 19,
//                Description = "podawany z sałatką z sosem balsamicznym",
//                DietInfoTags = new List<DietInfoTag>(),

//                ProductIngredients = new List<Ingredient>
//                {
//                        new Ingredient{Id = 1, Name = "Bajgiel"},
//                        new Ingredient{Id = 2, Name = "Wołowina"},
//                        new Ingredient{Id = 3, Name = "Mozarella"},
//                        new Ingredient{Id = 4, Name = "Warzywa"}
//                },
//                ProductAllergens = new List<Allergen>
//                {
//                    new Allergen{Id = 1, Name ="Mleko"},
//                    new Allergen{Id = 2, Name ="Orzechy"}
//                },
//            };
//            Product product2 = new Product()
//            {
//                Id = 2,
//                Name = "Bajgiel Kurczak",
//                Price = 17,
//                Description = "podawany z sałatką z sosem balsamicznym",
//                DietInfoTags = new List<DietInfoTag>(),
//                ProductIngredients = new List<Ingredient>
//                {
//                    new Ingredient{Id = 1, Name = "Bajgiel"},
//                    new Ingredient{Id = 5, Name = "Kurczak"},
//                    new Ingredient{Id = 6, Name = "Cebula prażona"},
//                    new Ingredient{Id = 4, Name = "Warzywa"}
//                },
//                ProductAllergens = new List<Allergen>
//                {
//                    new Allergen{Id = 1, Name ="Mleko"},
//                    new Allergen{Id = 2, Name ="Orzechy"}
//                },
//            };

//            Product product3 = new Product()
//            {
//                Id = 3,
//                Name = "Bajgiel Camembert",
//                Price = 16,
//                Description = "podawany z sałatką z sosem balsamicznym",
//                DietInfoTags = new List<DietInfoTag>()
//                {

//                    new DietInfoTag(){Id = 2, Name = "Vegetarian"},


//                },
//                ProductIngredients = new List<Ingredient>
//                {
//                    new Ingredient{Id = 1, Name = "Bajgiel"},
//                    new Ingredient{Id = 7, Name = "Camembert"},
//                    new Ingredient{Id = 8, Name = "Żurawina"},
//                    new Ingredient{Id = 4, Name = "Warzywa"}
//                },
//                ProductAllergens = new List<Allergen>
//                {
//                    new Allergen{Id = 1, Name ="Mleko"},
//                    new Allergen{Id = 2, Name ="Orzechy"}
//                },
//            };
//            Product product4 = new Product()
//            {
//                Id = 4,
//                Name = "Bajgiel Falafel",
//                Price = 17,
//                Description = "podawany z sałatką z sosem balsamicznym",
//                DietInfoTags = new List<DietInfoTag>()
//                {
//                    new DietInfoTag(){Id = 2, Name = "Vegetarian"},
//                    new DietInfoTag(){Id = 3, Name = "Vegan"}
//                },
//                ProductIngredients = new List<Ingredient>
//                {
//                    new Ingredient{Id = 1, Name = "Bajgiel"},
//                    new Ingredient{Id = 9, Name = "Falafel"},
//                    new Ingredient{Id = 10, Name = "Ogórek konserwowy"},
//                    new Ingredient{Id = 4, Name = "Warzywa"}
//                },
//                ProductAllergens = new List<Allergen>
//                {
//                    new Allergen{Id = 3, Name ="Soja"},
//                    new Allergen{Id = 2, Name ="Orzechy"}
//                },
//            };
//            List<Product> productsForBajgleMenu = new List<Product>()
//            { product1,
//              product2,
//              product3,
//              product4
//            };
//            return productsForBajgleMenu;
//        }

//        public List<Product> GetProductsForNalesnikiMenu()
//        {
//            Product product5 = new Product()
//            {
//                Id = 5,
//                Name = "Naleśnik Oreo",
//                Price = 10,
//                Description = "",
//                DietInfoTags = new List<DietInfoTag>()
//                {

//                    new DietInfoTag(){Id = 2, Name = "Vegetarian"},


//                },
//                ProductIngredients = new List<Ingredient>
//                {
//                    new Ingredient{Id = 11, Name = "dżem"},
//                    new Ingredient{Id = 12, Name = "sos owocowy"},
//                    new Ingredient{Id = 13, Name = "śmietana"},
//                },
//                ProductAllergens = new List<Allergen>
//                {
//                    new Allergen{Id = 1, Name ="Mleko"},
//                    new Allergen{Id = 2, Name ="Orzechy"}
//                },
//            };

//            Product product6 = new Product()
//            {
//                Id = 6,
//                Name = "Naleśnik Hiszpański",
//                Price = 13,
//                Description = "sos 1000 wysp własnej produkcji",
//                DietInfoTags = new List<DietInfoTag>(),
//                ProductIngredients = new List<Ingredient>
//                {
//                    new Ingredient{Id = 14, Name = "chorizo"},
//                    new Ingredient{Id = 3, Name = "mozarella"},
//                    new Ingredient{Id = 15, Name = "suszone pomidory"},
//                },
//                ProductAllergens = new List<Allergen>
//                {
//                    new Allergen{Id = 1, Name ="Mleko"},
//                    new Allergen{Id = 2, Name ="Orzechy"}
//                },
//            };

//            Product product7 = new Product()
//            {
//                Id = 7,
//                Name = "Naleśnik Łosoś",
//                Price = 13,
//                Description = "",
//                DietInfoTags = new List<DietInfoTag>(),
//                ProductIngredients = new List<Ingredient>
//                {
//                    new Ingredient{Id = 16, Name = "Łosoś"},
//                    new Ingredient{Id = 17, Name = "Szpinak"},
//                    new Ingredient{Id = 18, Name = "Ser feta"},
//                },
//                ProductAllergens = new List<Allergen>
//                {
//                    new Allergen{Id = 1, Name ="Mleko"},
//                    new Allergen{Id = 2, Name ="Orzechy"}
//                },
//            };

//            Product product8 = new Product()
//            {
//                Id = 8,
//                Name = "Naleśnik kebab",
//                Price = 13,
//                Description = "",
//                DietInfoTags = new List<DietInfoTag>(),
//                ProductIngredients = new List<Ingredient>
//                {
//                    new Ingredient{Id = 19, Name = "Kebab"},
//                    new Ingredient{Id = 20, Name = "Papryka"},
//                    new Ingredient{Id = 21, Name = "Kukurydza"},
//                },
//                ProductAllergens = new List<Allergen>
//                {
//                    new Allergen{Id = 1, Name ="Mleko"},
//                    new Allergen{Id = 2, Name ="Orzechy"}
//                },
//            };

//            List<Product> NalesnikiMenuProducts = new List<Product>
//            {
//                product5,
//                product6,
//                product7,
//                product8
//            };
//            return NalesnikiMenuProducts;
//        }
//        public List<Product> GetAllProductsForTest()
//        {
//            List<Product> nalesnikiMenu = GetProductsForNalesnikiMenu();
//            List<Product> allProducts = GetProductsForBajgleMenu();
//            allProducts.AddRange(nalesnikiMenu);

//            return allProducts;
//        }
//    }
//}
