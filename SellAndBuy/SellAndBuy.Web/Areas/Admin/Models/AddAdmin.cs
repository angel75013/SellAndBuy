using AutoMapper;
using SellAndBuy.Data.Models;
using SellAndBuy.Web.Infrastructure;
using System;

namespace SellAndBuy.Web.Areas.Admin.Models
{
    public class AddAdmin : IMap<Add>, IHaveCustomMappings
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public double Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public string UserName { get; set; }
        public string CityName { get; set; }
        public string CategorieName { get; set; }
        public void CreateMappings(IMapperConfigurationExpression configuration)
        {

            configuration.CreateMap<Add, AddAdmin>()

           .ForMember(addAdmin => addAdmin.UserName, cfg => cfg.MapFrom(add => add.User.Name))
           .ForMember(addAdmin => addAdmin.CityName, cfg => cfg.MapFrom(add => add.City.Name))
           .ForMember(addAdmin => addAdmin.CategorieName, cfg => cfg.MapFrom(add => add.Category.CategorieName));

        }
    }
}