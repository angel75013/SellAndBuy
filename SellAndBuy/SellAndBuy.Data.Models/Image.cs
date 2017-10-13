using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Data.Models
{
    public class Image
    {

        public Image()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }

       
    }
}
