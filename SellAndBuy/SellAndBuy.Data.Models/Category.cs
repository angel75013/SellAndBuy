using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Id = Guid.NewGuid();
            this.Adds = new HashSet<Add>();

        }
        public Guid Id { get; set; }

        public CategoriesEnum CategorieName { get; set; }

        public virtual ICollection<Add> Adds { get; set; }
    }
}
