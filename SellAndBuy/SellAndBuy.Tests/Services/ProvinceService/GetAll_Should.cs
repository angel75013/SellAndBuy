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

namespace SellAndBuy.Tests.Services.ProvinceService
{
    [TestFixture]
    public class GetAll_Should
    {
        private Mock<IEfRepository<Province>> provinceRepoMocked;
        private IEfUnitOfWork unitOfWork;
        private IQueryable<Province> provinces;

        [SetUp]
        public void Init()
        {
            this.provinceRepoMocked = new Mock<IEfRepository<Province>>();
            this.unitOfWork = new Mock<IEfUnitOfWork>().Object;

            this.provinces = new List<Province>
            {
                new Province { ProvinceName = "Sofia" },
                new Province { ProvinceName = "Burgas" },
                
            }.AsQueryable();

            provinceRepoMocked.Setup(x => x.All).Returns(provinces);
        }
        [Test]
        public void ReturnQueryable_WithExactNumber()
        {
            // Arrange
            var provinceService = new ProvincesServices(this.provinceRepoMocked.Object, this.unitOfWork);

            // Act 
            var expectedNumberProvinces = provinceService.GetAll().Count();

            // Assert
            Assert.AreEqual(expectedNumberProvinces, this.provinces.Count());
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var provinceService = new ProvincesServices(this.provinceRepoMocked.Object, this.unitOfWork);

            // Act 
            provinceService.GetAll();

            // Assert
            this.provinceRepoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
