using NUnit.Framework;
using SellAndBuy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Tests.Data.DbContextShould
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void Create_Should_ReturnNewDbContextInstance()
        {
            // Arrange & Act
            var newContext = SqlDbContext.Create();

            // Assert
            Assert.IsNotNull(newContext);
            Assert.IsInstanceOf<ISqlDbContext>(newContext);
        }
    }
}
