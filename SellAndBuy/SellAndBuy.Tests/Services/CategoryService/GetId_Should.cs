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
    [TestFixture]
    public class GetId_Should
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
                new Category { CategorieName = "one",Id=1 }

            }.AsQueryable();
            repoMocked.Setup(x => x.All).Returns(cat);

        }

        [Test]
        public void ReturnExpectedCategory()
        {
            // Arrange
            var citiesService = new CategoriesServices(this.repoMocked.Object, this.unitOfWork);
            var expectedPro = new Category() { CategorieName = "one",Id=1 };

            // Act 
            var res = citiesService.GetId(expectedPro.CategorieName);

            // Assert
            Assert.AreEqual(expectedPro.Id, res);
        }

        [Test]
        public void GetId_ShouldbeCalledOnce()
        {
            // Arrange
            var catService = new CategoriesServices(this.repoMocked.Object, this.unitOfWork);
            var expectedPro = new Category() { CategorieName = "one", Id = 1 };
            // Act 
            var res = catService.GetId(expectedPro.CategorieName);

            // Assert
            this.repoMocked.Verify(x => x.All, Times.Once);

        }
    }
}
