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
    public class GetId_Should
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
                new City { Name = "Sofia", Id = 1,ProvinceId=1 }

            }.AsQueryable();
            repoMocked.Setup(x => x.All).Returns(cities);

        }

        [Test]
        public void ReturnExpectedCity()
        {
            // Arrange
            var citiesService = new CitiesServices(this.repoMocked.Object, this.unitOfWork);
            var expectedPro = new City() { Name = "Sofia", Id = 1, ProvinceId = 1 };

            // Act 
            var res = citiesService.GetId("Sofia");

            // Assert
            Assert.AreEqual(expectedPro.Id, res);
        }

        [Test]
        public void GetId_ShouldbeCalledOnce()
        {
            // Arrange
            var provinceService = new CitiesServices(this.repoMocked.Object, this.unitOfWork);
            var expectedPro = new City() { Name = "Sofia", Id = 1, ProvinceId = 1 };
            // Act 
            var res = provinceService.GetId("Sofia");

            // Assert
            this.repoMocked.Verify(x => x.All, Times.Once);

        }
    }
}
