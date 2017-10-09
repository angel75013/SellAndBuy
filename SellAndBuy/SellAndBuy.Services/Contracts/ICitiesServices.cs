using SellAndBuy.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace SellAndBuy.Services.Contracts
{
    public interface ICitiesServices: IService
    {
        IQueryable<City> GetAll();
        int GetId(string str);
        IQueryable<City> GetCitiesByProvinceId(int provinceId);

    }
}