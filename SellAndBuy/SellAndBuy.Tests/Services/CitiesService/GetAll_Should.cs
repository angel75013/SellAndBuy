using Moq;
using NUnit.Framework;
using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Data.UnitOfWork;
using SellAndBuy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Tests.Services.CitiesService
{
    [TestFixture]
    public class GetAll_Should
    {
        private Mock<IEfRepository<City>> repoMocked;
        private IEfUnitOfWork unitOfWork;
        private IQueryable<City> cities;

        [SetUp]
        public void Init()
        {
            this.repoMocked = new Mock<IEfRepository<City>>();
            this.unitOfWork = new Mock<IEfUnitOfWork>().Object;

            this.cities = new List<City>
            {
                new City { Name = "Sofia", Id = 1,ProvinceId=1 },
                new City { Name = "Balchik", Id = 2,ProvinceId=1 }

            }.AsQueryable();
            repoMocked.Setup(x => x.All).Returns(cities);

        }
        [Test]
        public void ReturnQueryable_WithExactNumber()
        {
            // Arrange
            var citiesService = new CitiesServices(this.repoMocked.Object, this.unitOfWork);

            // Act 
            var expectedNumberProvinces = citiesService.GetAll().Count();

            // Assert
            Assert.AreEqual(expectedNumberProvinces, this.cities.Count());
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var provinceService = new CitiesServices(this.repoMocked.Object, this.unitOfWork);

            // Act 
            provinceService.GetAll();

            // Assert
            this.repoMocked.Verify(x => x.All, Times.Once);
        }
    }


}
