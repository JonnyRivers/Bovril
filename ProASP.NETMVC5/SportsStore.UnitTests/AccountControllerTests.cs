using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void TestValidLoginSucceeds()
        {
            // Arrange
            Mock<IAuthenticationProvider> authenticatonProviderMock = new Mock<IAuthenticationProvider>();
            authenticatonProviderMock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);

            AccountController accountController = new AccountController(authenticatonProviderMock.Object);

            LoginViewModel viewModel = new LoginViewModel
            {
                UserName = "admin",
                Password = "secret"
            };

            // Act
            ActionResult result = accountController.Login(viewModel, "/MyURL");

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            RedirectResult redirectResult = (RedirectResult)result;
            Assert.AreEqual(redirectResult.Url, "/MyURL");
        }

        [TestMethod]
        public void TestInvalidLoginFails()
        {
            // Arrange
            Mock<IAuthenticationProvider> authenticatonProviderMock = new Mock<IAuthenticationProvider>();
            authenticatonProviderMock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);

            AccountController accountController = new AccountController(authenticatonProviderMock.Object);

            LoginViewModel viewModel = new LoginViewModel
            {
                UserName = "baduser",
                Password = "badpassword"
            };

            // Act
            ActionResult result = accountController.Login(viewModel, "/MyURL");

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsFalse(viewResult.ViewData.ModelState.IsValid);
        }
    }
}
