using CafeMVC.Application.ViewModels.Products;
using CafeMVC.Domain.Model;
using System.Collections.Generic;

namespace CafeMVC.Application.Helpers
{
    public class AllergenComparerHelper : IEqualityComparer<ProductAllergen>, IEqualityComparer<AllergenForViewVm>
    {
        public bool Equals(AllergenForViewVm x, AllergenForViewVm y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(AllergenForViewVm obj)
        {
            if (ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.Id.GetHashCode();

            return hashProductCode;
        }

        public bool Equals(ProductAllergen x, ProductAllergen y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.AllergenId == y.AllergenId;
        }

        public int GetHashCode(ProductAllergen obj)
        {
            if (ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.AllergenId.GetHashCode();

            return hashProductCode;
        }
    }
}
