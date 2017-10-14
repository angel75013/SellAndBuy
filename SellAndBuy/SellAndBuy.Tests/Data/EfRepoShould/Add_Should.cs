using Moq;
using NUnit.Framework;
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
    public class Add_Should
    {
        [Test]
        public void VerifyThatAddsUser_WhenPassedParametersAreValid()
        {
            // Arrange
            var categor = new Category();
            categor.CategorieName = "outher";

            var mockedRepository = new Mock<IEfRepository<Category>>();
            mockedRepository.Setup(r => r.Add(categor)).Verifiable();

            // Act
            mockedRepository.Object.Add(categor);

            // Assert
            mockedRepository.Verify(r => r.Add(categor), Times.Exactly(1));
        }

        [Test]
        public void VerifyThatNotAddUser_WhenPassedParametersAreInValid()
        {
            // Arrange
            var categor = new Category();
            categor.CategorieName = "outher";

            var mockedRepository = new Mock<IEfRepository<Category>>();
            mockedRepository.Setup(r => r.Add(categor)).Verifiable();

            // Act
            mockedRepository.Object.Add(categor);
            mockedRepository.Object.Add(categor);

            // Assert
            mockedRepository.Verify(r => r.Add(categor), Times.Exactly(2));
        }
    }
}

