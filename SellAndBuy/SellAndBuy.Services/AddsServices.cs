using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Data.UnitOfWork;
using SellAndBuy.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Services
{
    public class AddsServices: IAddsServices
    {
        private readonly IEfRepository<Add> adds;
        private readonly IEfUnitOfWork context;

        public AddsServices(IEfRepository<Add> adds, IEfUnitOfWork context)
        {
            this.adds = adds;
            this.context = context;
        }
        public IQueryable<Add> GetAll()
        {
            return this.adds.All;
        }
        
        public Add FindById(Guid addId)
        {
            return this.adds.All.FirstOrDefault(x=>x.Id==addId);
        }
        public  void  FindByIdAndDelete(Guid addId)
        {
            var result= this.adds.All.FirstOrDefault(x => x.Id == addId);
            result.IsDeleted = true;
            context.Commit();
        }
       
        public void CreateAdd(string userId,int city, int category, double price, string description, string ImgName)
        {
            var currTime = DateTime.Now;
            var add = new Add();
            add.UserId = userId;
            add.CategoryId = category;
            add.Description = description;
            add.CityId = city;
            add.CreatedOn = currTime;
            add.Price = price;
            add.IsDeleted = false;
            add.ImgName = ImgName;

            this.adds.Add(add);
            this.context.Commit();

        }       

        public IQueryable<Add> GetAllNotDeleted()
        {
            var res = this.adds.All.Where(x => x.IsDeleted == false);
            return res;
        }
    }
}
