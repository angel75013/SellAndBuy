using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace SellAndBuy.Web.Models.Adds.AddModels
{
    public class AddDetailViewModel : IMap<Add>, IHaveCustomMappings
    {
        public string Description { get; set; }
        public Guid Id { get; set; }
        public string ImgName { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }


        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Add, AddDetailViewModel>()

           .ForMember(addDetailViewModel => addDetailViewModel.IsDeleted, cfg => cfg.MapFrom(add => add.IsDeleted))
           .ForMember(addDetailViewModel => addDetailViewModel.Phone, cfg => cfg.MapFrom(add => add.User.PhoneNumber))

           .ForMember(addDetailViewModel => addDetailViewModel.Email, cfg => cfg.MapFrom(add => add.User.Email))

           .ForMember(addDetailViewModel => addDetailViewModel.UserName, cfg => cfg.MapFrom(add => add.User.Name));
        }

    }
}