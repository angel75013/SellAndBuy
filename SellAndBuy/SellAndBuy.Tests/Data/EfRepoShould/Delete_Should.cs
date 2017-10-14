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
    public class Delete_Should
    {
        [Test]
        public void VerifyThatDeleteUserCorrectlyByObject_WhenPassedParametersAreValid()
        {
            // Arrange
            var categor = new Category();
            categor.CategorieName = "outher";

            var mockedRepository = new Mock<IEfRepository<Category>>();
            mockedRepository.Setup(r => r.Add(categor)).Verifiable();
            mockedRepository.Setup(r => r.Delete(categor)).Verifiable();

            // Act
            mockedRepository.Object.Add(categor);
            mockedRepository.Object.Add(categor);
            mockedRepository.Object.Delete(categor);
            

            // Assert
            mockedRepository.Verify(r => r.Delete(categor), Times.Exactly(1));
        }
    }
}
