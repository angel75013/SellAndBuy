using NUnit.Framework;
using SellAndBuy.Web.Controllers;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellAndBuy.Tests.Web.ControllersTest.HomeControl
{
    [TestFixture]
    public class HomeControllerTest
    {

        [Test]
        public void ReturnDefaultViewIndex()
        {
            // Arrange
            var homeController = new HomeController();

            // Act & Assert
            homeController
                           .WithCallTo(c => c.Index())
                           .ShouldRenderDefaultView();
        }

        [Test]
        public void ReturnDefaultViewContact()
        {
            // Arrange
            var homeController = new HomeController();

            // Act & Assert
            homeController
                           .WithCallTo(c => c.Contact())
                           .ShouldRenderDefaultView();
        }


        [Test]
        public void ReturnDefaulViewAbout()
        {
            // Arrange
            var homeController = new HomeController();

            // Act & Assert
            homeController
                          .WithCallTo(c => c.About())
                          .ShouldRenderDefaultView();
        }

    }
}
