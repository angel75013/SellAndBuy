using SellAndBuy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellAndBuy.Web.Models.Adds.AddModels
{
    public class CreationalAddModel
    {
        public string CityName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public HttpPostedFileBase File { get; set; }
        
    }
}