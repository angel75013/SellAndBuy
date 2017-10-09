using SellAndBuy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellAndBuy.Web.Models.Adds
{
    public class SearchViewModel
    {

        public string Description { get; set; }
        public string Province { get; set; }
        public string Category { get; set; }
        public string City { get; set; }



        public ICollection<string> Provinces { get; set; }

        public ICollection<string> Cities { get; set; }

        public ICollection<string> Categories { get; set; }

        
    }
}