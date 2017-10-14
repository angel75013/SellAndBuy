using Moq;
using NUnit.Framework;
using SellAndBuy.Data;
using SellAndBuy.Data.Models;
using SellAndBuy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Tests.Data.EfRepoShould
{
    [TestFixture]
    public class All_Should
    {
        [Test]
        public void ReturnEntitiesOfGivenSet()
        {
            // Arrange
            var categor = new Category();
            categor.CategorieName = "outher";
            var categor2 = new Category();
            categor2.CategorieName = "fashion";

            var col = new List<Category>();
            col.Add(categor);
            col.Add(categor2);

            var mockedRepository = new Mock<IEfRepository<Category>>();
            mockedRepository.Setup(r => r.All).Returns(col.AsQueryable());

            // Act
            var result = mockedRepository.Object.All;

            // Assert
            mockedRepository.Verify(r => r.All, Times.Exactly(1));
            Assert.AreEqual(result.Count(), 2);
        }
    }
}
