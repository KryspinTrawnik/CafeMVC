using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CafeMVC.Application.Services
{
    
    public class Helper : IEqualityComparer<AllergenForViewVm>, IEqualityComparer<IngredientForViewVm>, IEqualityComparer<ProductIngredient>
        , IEqualityComparer<ProductAllergen> , IEqualityComparer<ProductDietInfoTag>, IEqualityComparer<int>
    {
        public static double StringToDouble(string numberToConvert)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            if(numberToConvert.Contains(",") == true)
            {
                numberToConvert = numberToConvert.Replace(",", ".");
            }
            double result = Double.TryParse(numberToConvert, out result) ? Convert.ToDouble(numberToConvert) : 0;

            return result;
        }

        public bool Equals(AllergenForViewVm x, AllergenForViewVm y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(AllergenForViewVm allergen)
        {
            if (Object.ReferenceEquals(allergen, null)) return 0;

            int hashProductName = allergen.Name == null ? 0 : allergen.Name.GetHashCode();

            int hashProductCode = allergen.Id.GetHashCode();

            return hashProductName ^ hashProductCode;
        }

        public bool Equals(IngredientForViewVm x, IngredientForViewVm y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(IngredientForViewVm ingredient)
        {
            if (Object.ReferenceEquals(ingredient, null)) return 0;

            int hashProductName = ingredient.Name == null ? 0 : ingredient.Name.GetHashCode();

            int hashProductCode = ingredient.Id.GetHashCode();

            return hashProductName ^ hashProductCode;
        }

        public bool Equals(ProductIngredient x, ProductIngredient y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.IngredientId == y.IngredientId;
        }

        public int GetHashCode(ProductIngredient obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.IngredientId.GetHashCode();

            return hashProductCode;
        }

        public bool Equals(ProductAllergen x, ProductAllergen y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.AllergenId == y.AllergenId;
        }

        public int GetHashCode(ProductAllergen obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.AllergenId.GetHashCode();

            return hashProductCode;
        }

        public bool Equals(ProductDietInfoTag x, ProductDietInfoTag y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.DietInfoTagId == y.DietInfoTagId;
        }

        public int GetHashCode(ProductDietInfoTag obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.DietInfoTagId.GetHashCode();

            return hashProductCode;
        }

        public bool Equals(int x, int y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x == y;
        }

        public int GetHashCode(int obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.GetHashCode();

            return hashProductCode;
        }
    }
}
