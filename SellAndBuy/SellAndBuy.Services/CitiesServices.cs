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
    public class CitiesServices:ICitiesServices
    {
        private readonly IEfRepository<City> cities;
        private readonly IEfUnitOfWork context;

        public CitiesServices(IEfRepository<City> cities, IEfUnitOfWork context)
        {
            this.cities = cities;
            this.context = context;
        }
        public IQueryable<City> GetAll()
        {

            return this.cities.All;
        }
        public int GetId(string city)
        {
            return cities.All.FirstOrDefault(x => x.Name == city).Id;
        }
        public IQueryable<City> GetCitiesByProvinceId(int provinceId)
        {
            return cities.All.Where(x => x.ProvinceId == provinceId);
        }
       
    }
}
