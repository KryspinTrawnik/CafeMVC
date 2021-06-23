using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Tests
{
    public class ProductsForTesting
    {
        public List<Product> GetProductsForTesting()
        {
            List<Product> AllProducts = new List<Product>();
            ProductType Bajgle = new ProductType()
            {
                Id = 1,
                Name = "Bajgle",
                Products = new List<Product>()
            };

            ProductType Nalesniki = new ProductType()
            {
                Id = 2,
                Name = "Nalesniki",
                Products = new List<Product>()
            };

            Product product1 = new Product()
            {
                Id = 1,
                Name = "Bajgiel Burger",
                Price = 19,
                Description = "podawany z sałatką z sosem balsamicznym",
                TypeId = 1,
                ProductType = Bajgle,
                DietInformation = new DietInformation
                {
                    Id = 1,
                    IsGlutenFree = false,
                    IsVegan = false,
                    IsVegetarian = false
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{Id = 1, Name = "Bajgiel"},
                    new Ingredient{Id = 2, Name = "Wołowina"},
                    new Ingredient{Id = 3, Name = "Mozarella"},
                    new Ingredient{Id = 4, Name = "Warzywa"}
                },
                Allergens = new List<Allergen>
                {
                    new Allergen{Id = 1, Name ="Mleko"},
                    new Allergen{Id = 2, Name ="Orzechy"}
                },
            };
            Product product2 = new Product()
            {
                Id = 2,
                Name = "Bajgiel Kurczak",
                Price = 17,
                Description = "podawany z sałatką z sosem balsamicznym",
                TypeId = 1,
                ProductType = Bajgle,
                DietInformation = new DietInformation
                {
                    Id = 1,
                    IsGlutenFree = false,
                    IsVegan = false,
                    IsVegetarian = false
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{Id = 1, Name = "Bajgiel"},
                    new Ingredient{Id = 5, Name = "Kurczak"},
                    new Ingredient{Id = 6, Name = "Cebula prażona"},
                    new Ingredient{Id = 4, Name = "Warzywa"}
                },
                Allergens = new List<Allergen>
                {
                    new Allergen{Id = 1, Name ="Mleko"},
                    new Allergen{Id = 2, Name ="Orzechy"}
                },
            };

            Product product3 = new Product()
            {
                Id = 3,
                Name = "Bajgiel Camembert",
                Price = 16,
                Description = "podawany z sałatką z sosem balsamicznym",
                TypeId = 1,
                ProductType = Bajgle,
                DietInformation = new DietInformation
                {
                    Id = 2,
                    IsGlutenFree = false,
                    IsVegan = false,
                    IsVegetarian = true
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{Id = 1, Name = "Bajgiel"},
                    new Ingredient{Id = 7, Name = "Camembert"},
                    new Ingredient{Id = 8, Name = "Żurawina"},
                    new Ingredient{Id = 4, Name = "Warzywa"}
                },
                Allergens = new List<Allergen>
                {
                    new Allergen{Id = 1, Name ="Mleko"},
                    new Allergen{Id = 2, Name ="Orzechy"}
                },
            };
            Product product4 = new Product()
            {
                Id = 4,
                Name = "Bajgiel Falafel",
                Price = 17,
                Description = "podawany z sałatką z sosem balsamicznym",
                TypeId = 1,
                ProductType = Bajgle,
                DietInformation = new DietInformation
                {
                    Id = 3,
                    IsGlutenFree = false,
                    IsVegan = true,
                    IsVegetarian = true
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{Id = 1, Name = "Bajgiel"},
                    new Ingredient{Id = 9, Name = "Falafel"},
                    new Ingredient{Id = 10, Name = "Ogórek konserwowy"},
                    new Ingredient{Id = 4, Name = "Warzywa"}
                },
                Allergens = new List<Allergen>
                {
                    new Allergen{Id = 3, Name ="Soja"},
                    new Allergen{Id = 2, Name ="Orzechy"}
                },
            };
            Bajgle.Products.Add(product1);
            Bajgle.Products.Add(product2);
            Bajgle.Products.Add(product3);
            Bajgle.Products.Add(product4);

            Product product5 = new Product()
            {
                Id = 5,
                Name = "Naleśnik Oreo",
                Price = 10,
                Description = "",
                TypeId = 2,
                ProductType = Nalesniki,
                DietInformation = new DietInformation
                {
                    Id = 2,
                    IsGlutenFree = false,
                    IsVegan = false,
                    IsVegetarian = true
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{Id = 11, Name = "dżem"},
                    new Ingredient{Id = 12, Name = "sos owocowy"},
                    new Ingredient{Id = 13, Name = "śmietana"},
                },
                Allergens = new List<Allergen>
                {
                    new Allergen{Id = 1, Name ="Mleko"},
                    new Allergen{Id = 2, Name ="Orzechy"}
                },
            };

            Product product6 = new Product()
            {
                Id = 6,
                Name = "Naleśnik Hiszpański",
                Price = 13,
                Description = "sos 1000 wysp własnej produkcji",
                TypeId = 2,
                ProductType = Nalesniki,
                DietInformation = new DietInformation
                {
                    Id = 1,
                    IsGlutenFree = false,
                    IsVegan = false,
                    IsVegetarian = false
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{Id = 14, Name = "chorizo"},
                    new Ingredient{Id = 3, Name = "mozarella"},
                    new Ingredient{Id = 15, Name = "suszone pomidory"},
                },
                Allergens = new List<Allergen>
                {
                    new Allergen{Id = 1, Name ="Mleko"},
                    new Allergen{Id = 2, Name ="Orzechy"}
                },
            };

            Product product7 = new Product()
            {
                Id = 7,
                Name = "Naleśnik Łosoś",
                Price = 13,
                Description = "",
                TypeId = 2,
                ProductType = Nalesniki,
                DietInformation = new DietInformation
                {
                    Id = 1,
                    IsGlutenFree = false,
                    IsVegan = false,
                    IsVegetarian = false
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{Id = 16, Name = "Łosoś"},
                    new Ingredient{Id = 17, Name = "Szpinak"},
                    new Ingredient{Id = 18, Name = "Ser feta"},
                },
                Allergens = new List<Allergen>
                {
                    new Allergen{Id = 1, Name ="Mleko"},
                    new Allergen{Id = 2, Name ="Orzechy"}
                },
            };

            Product product8 = new Product()
            {
                Id = 8,
                Name = "Naleśnik kebab",
                Price = 13,
                Description = "",
                TypeId = 2,
                ProductType = Nalesniki,
                DietInformation = new DietInformation
                {
                    Id = 1,
                    IsGlutenFree = false,
                    IsVegan = false,
                    IsVegetarian = false
                },
                Ingredients = new List<Ingredient>
                {
                    new Ingredient{Id = 19, Name = "Kebab"},
                    new Ingredient{Id = 20, Name = "Papryka"},
                    new Ingredient{Id = 21, Name = "Kukurydza"},
                },
                Allergens = new List<Allergen>
                {
                    new Allergen{Id = 1, Name ="Mleko"},
                    new Allergen{Id = 2, Name ="Orzechy"}
                },
            };
            Nalesniki.Products.Add(product5);
            Nalesniki.Products.Add(product6);
            Nalesniki.Products.Add(product7);
            Nalesniki.Products.Add(product8);
            
            AllProducts.Add(product1);
            AllProducts.Add(product2);
            AllProducts.Add(product3);
            AllProducts.Add(product4);
            AllProducts.Add(product5);
            AllProducts.Add(product6);
            AllProducts.Add(product7);
            AllProducts.Add(product8);
            return AllProducts;
        }


    }
}
