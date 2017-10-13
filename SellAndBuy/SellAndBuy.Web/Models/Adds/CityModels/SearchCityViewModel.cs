using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellAndBuy.Web.Models.Adds.CityModels
{
    public class SearchCityViewModel : IMap<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int ProvinceId { get; set; }

    }
}