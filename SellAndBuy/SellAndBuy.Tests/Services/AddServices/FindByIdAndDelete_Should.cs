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
    public class FindByIdAndDelete_Should
    {
        private Mock<IEfRepository<Add>> repoMocked;
        private Mock<IEfUnitOfWork> unitOfWorkMocked;
        private IQueryable<Add> adds;
        Guid id1 = Guid.NewGuid();
        Guid id2 = Guid.NewGuid();
        Guid id3 = Guid.NewGuid();
        Guid id4 = Guid.NewGuid();

        [SetUp]
        public void Init()
        {
            this.repoMocked = new Mock<IEfRepository<Add>>();
            this.unitOfWorkMocked = new Mock<IEfUnitOfWork>();


            this.adds = new List<Add>
            {
              new Add { Description = "car", IsDeleted=false,Id = id1},
                new Add { Description = "car1", IsDeleted=false,Id =id2 },
                new Add { Description = "car2", IsDeleted=false,Id =id3 },
                new Add { Description = "cat", IsDeleted=true,Id = id4}

            }.AsQueryable();
            repoMocked.Setup(x => x.All).Returns(adds);
        }
        [Test]
        public void ShouldSet_IsDeleted()
        {
            // Arrange
            var addService = new AddsServices(this.repoMocked.Object, this.unitOfWorkMocked.Object);
            var foundAdd = addService.FindById(id3);

            // Act 
            addService.FindByIdAndDelete(id3);

            // Assert
            Assert.AreEqual(foundAdd.IsDeleted, true);
        }
        [Test]
        public void Should_CallCommit()
        {
            // Arrange
            var addService = new AddsServices(this.repoMocked.Object, this.unitOfWorkMocked.Object);
            

            // Act 
            addService.FindByIdAndDelete(id3);

            // Assert
            this.unitOfWorkMocked.Verify(x => x.Commit(), Times.Once);
        }
        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var addService = new AddsServices(this.repoMocked.Object, this.unitOfWorkMocked.Object);

            // Act 
            addService.FindById(id3);

            // Assert
            this.repoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
