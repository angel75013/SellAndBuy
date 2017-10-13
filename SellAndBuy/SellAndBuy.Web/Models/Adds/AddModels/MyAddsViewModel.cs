using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellAndBuy.Web.Models.Adds.AddModels
{
    public class MyAddsViewModel:IMap<Add>
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string ImgName { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public double Price { get; set; }
    }

}