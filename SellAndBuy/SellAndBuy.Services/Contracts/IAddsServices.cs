using SellAndBuy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SellAndBuy.Services.Contracts
{
    public interface IAddsServices: IService,IBaseService<Add>
    {        
        Add FindById(Guid addId);
        IQueryable<Add> GetAllNotDeleted();
        void FindByIdAndDelete(Guid addId);
        void CreateAdd(string userId, int city, int category, decimal price, string description, string ImgName);
    }
}