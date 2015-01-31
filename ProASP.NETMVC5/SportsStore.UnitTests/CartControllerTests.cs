using System;
using System.Linq;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartControllerTests
    {
        [TestMethod]
        public void TestAddToCart()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Apples"}
            });

            Cart cart = new Cart();

            CartController cartController = new CartController(mockBuilder.Object, null);

            // Act
            cartController.AddToCart(cart, 1, null);

            // Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.First().Product.ProductId, 1);
        }

        [TestMethod]
        public void TestAddToCartRedirect()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Apples"}
            });

            Cart cart = new Cart();

            CartController cartController = new CartController(mockBuilder.Object, null);

            // Act
            RedirectToRouteResult result = cartController.AddToCart(cart, 2, "myUrl");

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        [TestMethod]
        public void TestCartStatePersistence()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Apples"}
            });

            Cart cart = new Cart();

            CartController cartController = new CartController(null, null);

            // Act
            CartIndexViewModel viewModel = (CartIndexViewModel)cartController.Index(cart, "myUrl").ViewData.Model;

            // Assert
            Assert.AreEqual(viewModel.Cart, cart);
            Assert.AreEqual(viewModel.ReturnUrl, "myUrl");
        }

        [TestMethod]
        public void TestCheckoutWithEmptyCartFailure()
        {
            // Arrange
            Mock<IOrderProcessor> mockBuilder = new Mock<IOrderProcessor>();
            
            Cart cart = new Cart();

            ShippingDetails shippingDetails = new ShippingDetails();

            CartController cartController = new CartController(null, mockBuilder.Object);

            // Act
            ViewResult viewResult = cartController.Checkout(cart, shippingDetails);

            mockBuilder.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never);

            // Assert
            Assert.AreEqual("", viewResult.ViewName);
            Assert.AreEqual(false, viewResult.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void TestCheckoutWithInvalidShippingDetailsFailure()
        {
            // Arrange
            Mock<IOrderProcessor> mockBuilder = new Mock<IOrderProcessor>();

            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            CartController cartController = new CartController(null, mockBuilder.Object);
            cartController.ModelState.AddModelError("error", "error");

            // Act
            ViewResult viewResult = cartController.Checkout(cart, new ShippingDetails());

            mockBuilder.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never);

            // Assert
            Assert.AreEqual("", viewResult.ViewName);
            Assert.AreEqual(false, viewResult.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void TestCheckoutSuccess()
        {
            // Arrange
            Mock<IOrderProcessor> mockBuilder = new Mock<IOrderProcessor>();

            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            CartController cartController = new CartController(null, mockBuilder.Object);

            // Act
            ViewResult viewResult = cartController.Checkout(cart, new ShippingDetails());

            mockBuilder.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());

            // Assert
            Assert.AreEqual("Completed", viewResult.ViewName);
            Assert.AreEqual(true, viewResult.ViewData.ModelState.IsValid);
        }
    }
}
