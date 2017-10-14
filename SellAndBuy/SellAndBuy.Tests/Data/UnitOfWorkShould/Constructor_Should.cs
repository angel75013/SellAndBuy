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
    public class Constructor_Should
    {
        [Test]
        public void Constructor_PassDbContextNull_ShouldThrowArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EfUnitOfWork(null));
        }

        [Test]
        public void Constructor_PassDbContextCorrectly_ShouldNotThrow()
        {
            // Arrange
            var mockedDbContext = new Mock<ISqlDbContext>();

            // Act, Assert
            Assert.DoesNotThrow(() => new EfUnitOfWork(mockedDbContext.Object));
        }

        [Test]
        public void Constructor_PassDbContextCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedDbContext = new Mock<ISqlDbContext>();

            // Act
            var unitOfWork = new EfUnitOfWork(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(unitOfWork);
        }
    }
}
