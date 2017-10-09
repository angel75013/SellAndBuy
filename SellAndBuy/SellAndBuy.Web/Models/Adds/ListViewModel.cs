using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SellAndBuy.Web.Models.Adds
{
    public class ListViewModel   {
        
        public decimal Price { get; set; }

        public string Description { get; set; }              

        public string  CityName { get; set; }
                       
        public string Category { get; set; }

       
        public ICollection<string> Cities { get; set; }

        public ICollection<string> Provinces { get; set; }

        public ICollection<string> Categories { get; set; }

       
    }
}