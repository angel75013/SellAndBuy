using LinqToExcel;
using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Data.Models
{
    public class Province
    {
        public Province()
        {  
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }
       
        public string ProvinceName { get; set; }       
           
       
        public virtual ICollection<City> Cities { get; set; }
    }
}
