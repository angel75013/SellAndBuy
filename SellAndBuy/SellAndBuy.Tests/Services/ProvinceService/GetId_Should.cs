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
    public class GetId_Should
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
                new Province { ProvinceName = "Sofia", Id = 1}                

            }.AsQueryable();
            provinceRepoMocked.Setup(x => x.All).Returns(provinces);

        }

        [Test]
        public void ReturnExpectedProvince()
        {
            // Arrange
            var provinceService = new ProvincesServices(this.provinceRepoMocked.Object, this.unitOfWork);
            var expectedPro = new Province() { ProvinceName = "Sofia", Id = 1 };
            
            // Act 
            var res = provinceService.GetId("Sofia");

            // Assert
            Assert.AreEqual(expectedPro.Id, res);
        }

        [Test]
        public void GetId_ShouldbeCalledOnce()
        {
            // Arrange
            var provinceService = new ProvincesServices(this.provinceRepoMocked.Object, this.unitOfWork);
            var expectedPro = new Province() { ProvinceName = "Sofia", Id = 1 };
            // Act 
            var res = provinceService.GetId("Sofia");

            // Assert
          this.provinceRepoMocked.Verify(x => x.All, Times.Once);

        }
    }
}
