using Moq;
using NUnit.Framework;
using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Data.UnitOfWork;
using SellAndBuy.Services;
using SellAndBuy.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Tests.Services.ProvinceService
{
    [TestFixture]
    public class Constructor_Should
    {
        private IEfRepository<Province> provRepoMocked;
        private IEfUnitOfWork unitOfWorkMocked;

        [SetUp]
        public void Init()
        {
            this.provRepoMocked = new Mock<IEfRepository<Province>>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>().Object;
        }

     
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProvincesServices(null, this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ProvincesServices(this.provRepoMocked, null));
        }
        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new ProvincesServices(this.provRepoMocked, this.unitOfWorkMocked));
        }

        [Test]
        public void ReturnProvinceerviceInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newWineServices = new ProvincesServices(this.provRepoMocked, this.unitOfWorkMocked);

            // Assert
            Assert.IsInstanceOf<IProvincesServices>(newWineServices);
        }
    }
}
