using SellAndBuy.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SellAndBuy.Services.Contracts
{
    public interface IProvincesServices: IService
    {
        IQueryable<Province> GetAll();
        int GetId(string name);

    }
}