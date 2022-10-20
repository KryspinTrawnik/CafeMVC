using System.Collections.Generic;

namespace CafeMVC.Domain.Model
{
    public class Menu : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public bool IsItPublic { get; set; }

    }
}
