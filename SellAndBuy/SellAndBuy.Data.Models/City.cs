using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Data.Models
{
    public class City
    {
        public City()
        {
            this.Id = Guid.NewGuid();
            this.Adds = new HashSet<Add>();
            this.Categories = new HashSet<Category>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Add> Adds { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
