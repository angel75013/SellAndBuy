using SellAndBuy.Data.Models;
using SellAndBuy.Services.Contracts.Commun;
using System.Collections.Generic;
using System.Linq;

namespace SellAndBuy.Services.Contracts
{
    public interface ICitiesServices: IService,IBaseService<City>, IGeoService
    { 
        IQueryable<City> GetCitiesByProvinceId(int provinceId);
    }
}