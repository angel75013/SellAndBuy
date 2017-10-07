using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SellAndBuy.Web.Models.Adds
{
    public class AddViewModel:IMap<Add>, IHaveCustomMappings
    {
        public decimal Price { get; set; }

        public string Description { get; set; }

        public string PhotosPath { get; set; }

        public string  CityName { get; set; }

        public string  ProvinceName { get; set; }
                
        public CategoriesEnum Category { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //throw new NotImplementedException();
           // configuration.CreateMap < Add,AddViewModel>()
           //     .ForMember(AddViewModel=>...,cfg=>cgf.MapFrom(add=>add.)
        }
    }
}