using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SellAndBuy.Web.Models.Adds
{
    public class UserAddViewModel
    {
        public string Email { get; set; }


        public string Name { get; set; }

        public string TelephoneNumber { get; set; }
       
        public string CityName { get; set; }

       public AddViewModel Adds { get; set; }  

        

    }
}