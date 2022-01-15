using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class DietInfoTag : BaseModel
    {
        public string Name { get; set; }

        public string TagPathway { get; set; }

        public virtual ICollection<ProductDietInfoTag> ProductDietInfoTags { get; set; }
    }
}