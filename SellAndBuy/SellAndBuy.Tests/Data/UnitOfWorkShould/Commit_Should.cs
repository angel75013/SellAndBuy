using Moq;
using NUnit.Framework;
using SellAndBuy.Data;
using SellAndBuy.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Tests.Data.UnitOfWorkShould
{
    [TestFixture]

    public class Commit_Should
    {

        [Test]
        public void TestCommit_ShouldCallDbContextSaveChanges()
        {
            // Arrange
            var mockedDbContext = new Mock<ISqlDbContext>();

            var unitOfWork = new EfUnitOfWork(mockedDbContext.Object);

            // Act
            unitOfWork.Commit();

            // Assert
            mockedDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
