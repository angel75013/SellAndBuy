using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SellAndBuy.Web.Models.Adds
{
    public class AddViewModel : IMap<Add>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        public string Description { get; set; }
        public string ImgName { get; set; }

        public DateTime CreatedOn { get; set; }


        public string UserId { get; set; }
        public int CityId { get; set; }

        public int CategoryId { get; set; }
        public int ProvinceId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }


        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Add, AddViewModel>()
             .ForMember(addViewModel => addViewModel.ProvinceId, cfg => cfg.MapFrom(add => add.City.ProvinceId))
          
            .ForMember(addViewModel => addViewModel.IsDeleted, cfg => cfg.MapFrom(add => add.IsDeleted))
            
           .ForMember(addViewModel => addViewModel.Phone, cfg => cfg.MapFrom(add => add.User.PhoneNumber))
          
           .ForMember(addViewModel => addViewModel.Email, cfg => cfg.MapFrom(add => add.User.Email))
         
           .ForMember(addViewModel => addViewModel.Name, cfg => cfg.MapFrom(add => add.User.Name));

        }

    }
}