using SellAndBuy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SellAndBuy.Services.Contracts
{
    public interface IAddsServices: IService
    {
        IQueryable<Add> GetAll();
        Add FindById(Guid addId);
        void CreateAdd(string userId, int city, int category, decimal price, string description);

    }
}