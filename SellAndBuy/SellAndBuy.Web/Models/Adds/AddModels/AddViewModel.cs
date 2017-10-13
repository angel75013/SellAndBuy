using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SellAndBuy.Web.Models.Adds
{
    public class AddViewModel : IMap<Add>
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }
       
        public string Description { get; set; }
        public string ImgName { get; set; }

        public DateTime CreatedOn { get; set; }


        public string UserId { get; set; }
        public int CityId { get; set; }

        public int CategoryId { get; set; }
        public int ProvinceId { get; set; }      
    }
}