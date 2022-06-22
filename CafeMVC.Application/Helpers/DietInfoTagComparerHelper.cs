using CafeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMVC.Application.Helpers
{
    public class DietInfoTagComparerHelper : IEqualityComparer<ProductDietInfoTag>
    {
        public bool Equals(ProductDietInfoTag x, ProductDietInfoTag y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.DietInfoTagId == y.DietInfoTagId;
        }

        public int GetHashCode(ProductDietInfoTag obj)
        {
            if (ReferenceEquals(obj, null)) return 0;

            int hashProductCode = obj.DietInfoTagId.GetHashCode();

            return hashProductCode;
        }
    }
}
