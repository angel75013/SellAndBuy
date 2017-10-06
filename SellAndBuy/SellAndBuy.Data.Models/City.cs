using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using LinqToExcel.Attributes;

namespace SellAndBuy.Data.Models
{
    public class City
    {
        private ICollection<Add> adds;
        public City()
        {
            this.adds = new HashSet<Add>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }

        public virtual ICollection<Add> Adds
        {
            get { return this.adds; }
            set { this.adds = value; }
        }
    }
}
