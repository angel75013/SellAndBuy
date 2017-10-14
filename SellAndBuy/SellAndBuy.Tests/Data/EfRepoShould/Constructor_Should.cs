using Moq;
using NUnit.Framework;
using SellAndBuy.Data;
using SellAndBuy.Data.Repositories;
using SellAndBuy.Tests.Data.EfRepoShould.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Tests.Data.EfRepoShould
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Constructor_PassDbContextNull_ShouldThrowArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new EfRepostory<FakeRepository>(null));
        }

        [Test]
        public void Constructor_PassDbContextCorrectly_ShouldNotThrow()
        {
            // Arrange
            var mockedDbContext = new Mock<ISqlDbContext>();

            // Act & Assert
            Assert.DoesNotThrow(() => new EfRepostory<FakeRepository> (mockedDbContext.Object));
        }

        [Test]
        public void Constructor_PassDbContextCorrectly_ShouldInitializeCorrectly()
        {
            // Arrange
            var mockedDbContext = new Mock<ISqlDbContext>();

            // Act
            var repository = new EfRepostory<FakeRepository>(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(repository);
        }
    }
}
