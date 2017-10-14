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

namespace SellAndBuy.Tests.Services.CategoryService
{
    [
        TestFixture]
    public class GetAll_Should
    {
        private Mock<IEfRepository<Category>> repoMocked;
        private IEfUnitOfWork unitOfWork;
        private IQueryable<Category> cat;

        [SetUp]
        public void Init()
        {
            this.repoMocked = new Mock<IEfRepository<Category>>();
            this.unitOfWork = new Mock<IEfUnitOfWork>().Object;

            this.cat = new List<Category>
            {
                new Category { CategorieName = "edno" },
                new Category { CategorieName = "dve" },

            }.AsQueryable();

            repoMocked.Setup(x => x.All).Returns(cat);
        }
        [Test]
        public void ReturnQueryable_WithExactNumbe()
        {
            // Arrange
            var catService = new CategoriesServices(this.repoMocked.Object, this.unitOfWork);

            // Act 
            var expectedNumber = catService.GetAll().Count();

            // Assert
            Assert.AreEqual(expectedNumber, this.cat.Count());
        }

        [Test]
        public void Call_AllMethodFromRepositoryOnce()
        {
            // Arrange
            var provinceService = new CategoriesServices(this.repoMocked.Object, this.unitOfWork);

            // Act 
            provinceService.GetAll();

            // Assert
            this.repoMocked.Verify(x => x.All, Times.Once);
        }
    }
}
