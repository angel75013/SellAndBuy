using Moq;
using NUnit.Framework;
using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Data.UnitOfWork;
using System;
using SellAndBuy.Services;

namespace SellAndBuy.Tests.Services.AddServices
{

    [TestFixture]
    public class Constructor_Should
    {
        private IEfRepository<Add> repoMocked;
        private IEfUnitOfWork unitOfWorkMocked;

        [SetUp]
        public void Init()
        {
            this.repoMocked = new Mock<IEfRepository<Add>>().Object;
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>().Object;
        }


        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddsServices(null, this.unitOfWorkMocked));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddsServices(this.repoMocked, null));
        }
        [Test]
        public void NotThrow_WhenEverythingIsPassed()
        {
            // Act & Assert
            Assert.DoesNotThrow(() => new AddsServices(this.repoMocked, this.unitOfWorkMocked));
        }

        [Test]
        public void ReturnCitiServiceInstance_WhenCorrectDataIsPassed()
        {
            // Act
            var newSer = new AddsServices(this.repoMocked, this.unitOfWorkMocked);

            // Assert
            Assert.IsInstanceOf<SellAndBuy.Services.Contracts.IAddsServices>(newSer);
        }
    }
}
