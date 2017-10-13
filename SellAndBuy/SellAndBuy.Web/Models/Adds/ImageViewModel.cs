using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellAndBuy.Web.Models.Adds
{
    public class ImageViewModel:IMap<Image>
    {
        
        public Guid Id { get; set; }

        public string ImageUrl { get; set; }
        public Guid AddId { get; set; }

       
    }
}