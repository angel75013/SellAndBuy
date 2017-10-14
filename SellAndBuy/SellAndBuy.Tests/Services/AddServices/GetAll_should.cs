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
    public class GetAll_should
    {
        private Mock<IEfRepository<Add>> repoMocked;
        private IEfUnitOfWork unitOfWork;
        private IQueryable<Add> adds;

        [SetUp]
        public void Init()
        {
            this.repoMocked = new Mock<IEfRepository<Add>>();
            this.unitOfWork = new Mock<IEfUnitOfWork>().Object;

            this.adds = new List<Add>
            {
                new Add { Description = "car", IsDeleted=false,Id = Guid.NewGuid() }       
               
            }.AsQueryable();
            repoMocked.Setup(x => x.All).Returns(adds);

        }
        [Test]
        public void ReturnQueryable_WithExactNumber()
        {
            // Arrange
            var addService = new AddsServices(this.repoMocked.Object, this.unitOfWork);

            // Act 
            var expectedNumber = addService.GetAll().Count();

            // Assert
            Assert.AreEqual(expectedNumber, this.adds.Count());
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var addService = new AddsServices(this.repoMocked.Object, this.unitOfWork);

            // Act 
            addService.GetAll();

            // Assert
            this.repoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
