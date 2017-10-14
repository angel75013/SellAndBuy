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
    public class Constructor_Should
    {
        private IEfRepository<City> repoMocked;
        private IEfUnitOfWork unitOfWorkMocked;

        [SetUp]
        public void Init()
        {
            this.repoMocked = new Mock<IEfRepository<City>>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>().Object;
        }


        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CitiesServices(null, this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CitiesServices(this.repoMocked, null));
        }
        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new CitiesServices(this.repoMocked, this.unitOfWorkMocked));
        }

        [Test]
        public void ReturnCitiServiceInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newSer = new CitiesServices(this.repoMocked, this.unitOfWorkMocked);

            // Assert
            Assert.IsInstanceOf<SellAndBuy.Services.Contracts.ICitiesServices>(newSer);
        }
    }
}
