using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Data.Models
{
    public class Add
    {
        public Add()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
        public string ImgName { get; set; }


        [Index]
        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public int CityId { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
       

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual City City { get; set; }        

    }
}


