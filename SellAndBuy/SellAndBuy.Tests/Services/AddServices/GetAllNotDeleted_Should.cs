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

namespace SellAndBuy.Tests.Services.AddServices
{
    [TestFixture]
    public class GetAllNotDeleted_Should
    {
        private Mock<IEfRepository<Add>> repoMocked;
        private Mock<IEfUnitOfWork> unitOfWork;
        private IQueryable<Add> adds;

        [SetUp]
        public void Init()
        {
            this.repoMocked = new Mock<IEfRepository<Add>>();
            this.unitOfWork = new Mock<IEfUnitOfWork>();

            this.adds = new List<Add>
            {
                new Add { Description = "car", IsDeleted=false,Id = Guid.NewGuid() },
                new Add { Description = "car1", IsDeleted=false,Id = Guid.NewGuid() },
                new Add { Description = "car2", IsDeleted=false,Id = Guid.NewGuid() },
                new Add { Description = "cat", IsDeleted=true,Id = Guid.NewGuid() }

            }.AsQueryable();
            repoMocked.Setup(x => x.All).Returns(adds);

        }
        [Test]
        public void ReturnQueryable_WithExactNumber()
        {
            // Arrange
            var addService = new AddsServices(this.repoMocked.Object, this.unitOfWork.Object);

            // Act 
            var notDeleted = addService.GetAllNotDeleted().Count();

            // Assert
            Assert.AreEqual(notDeleted, 3);
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var addService = new AddsServices(this.repoMocked.Object, this.unitOfWork.Object);

            // Act 
            addService.GetAllNotDeleted();

            // Assert
            this.repoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
