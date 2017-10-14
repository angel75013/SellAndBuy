using Bytes2you.Validation;
using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Data.UnitOfWork;
using SellAndBuy.Services.Contracts;
using System.Linq;

namespace SellAndBuy.Services
{
    public class CitiesServices:ICitiesServices
    {
        private readonly IEfRepository<City> cities;
        private readonly IEfUnitOfWork context;

        public CitiesServices(IEfRepository<City> cities, IEfUnitOfWork context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(cities, "cities").IsNull().Throw();

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
