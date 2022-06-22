using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Model;
using System.Collections.Generic;

namespace CafeMVC.Application.Helpers
{
    public class IngredientComparerHelper : IEqualityComparer<ProductIngredient>, IEqualityComparer<IngredientForViewVm>
    {
        public bool Equals(ProductIngredient x, ProductIngredient y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.IngredientId == y.IngredientId;
        }

        public int GetHashCode(ProductIngredient obj)
        {
            if (ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.IngredientId.GetHashCode();

            return hashProductCode;
        }

        public bool Equals(IngredientForViewVm x, IngredientForViewVm y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(IngredientForViewVm ingredient)
        {
            if (ReferenceEquals(ingredient, null)) return 0;

            int hashProductName = ingredient.Name == null ? 0 : ingredient.Name.GetHashCode();

            int hashProductCode = ingredient.Id.GetHashCode();

            return hashProductName ^ hashProductCode;
        }

    }
}
