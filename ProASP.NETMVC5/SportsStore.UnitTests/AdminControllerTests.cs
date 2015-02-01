using System;
using System.Collections.Generic;
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
    public class AdminControllerTests
    {
        [TestMethod]
        public void TestIndexContainsAllProducts()
        {
            // Arrange
            Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();
            productRepoMock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"}
            });

            AdminController adminController = new AdminController(productRepoMock.Object);

            // Act
            Product[] result = ((IEnumerable<Product>)adminController.Index().ViewData.Model).ToArray();

            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0].Name, "P1");
            Assert.AreEqual(result[1].Name, "P2");
            Assert.AreEqual(result[2].Name, "P3");
        }

        [TestMethod]
        public void TestEdit()
        {
            // Arrange
            Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();
            productRepoMock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"}
            });

            AdminController adminController = new AdminController(productRepoMock.Object);

            // Act
            Product p1 = (Product)adminController.Edit(1).ViewData.Model;
            Product p2 = (Product)adminController.Edit(2).ViewData.Model;
            Product p3 = (Product)adminController.Edit(3).ViewData.Model;

            // Assert
            Assert.AreEqual(p1.ProductId, 1);
            Assert.AreEqual(p2.ProductId, 2);
            Assert.AreEqual(p3.ProductId, 3);
        }

        [TestMethod]
        public void TestEditNonExistentProduct()
        {
            // Arrange
            Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();
            productRepoMock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"}
            });

            AdminController adminController = new AdminController(productRepoMock.Object);

            // Act
            Product result = (Product)adminController.Edit(4).ViewData.Model;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestEditCanSaveValidChanges()
        {
            // Arrange
            Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();

            AdminController adminController = new AdminController(productRepoMock.Object);

            Product product = new Product { Name = "Test" };

            // Act
            ActionResult result = adminController.Edit(product);

            // Assert
            productRepoMock.Verify(m => m.SaveProduct(product));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void TestEditCannotSaveInvalidChanges()
        {
            // Arrange
            Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();

            AdminController adminController = new AdminController(productRepoMock.Object);

            Product product = new Product { Name = "Test" };

            adminController.ModelState.AddModelError("error", "error");

            // Act
            ActionResult result = adminController.Edit(product);

            // Assert
            productRepoMock.Verify(m => m.SaveProduct(product), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void TestDeleteExistingProduct()
        {
            // Arrange
            Product productToDelete = new Product { ProductId = 2, Name = "Test" };

            Mock<IProductRepository> productRepoMock = new Mock<IProductRepository>();
            productRepoMock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                productToDelete,
                new Product {ProductId = 3, Name = "P3"}
            });

            AdminController adminController = new AdminController(productRepoMock.Object);

            // Act
            adminController.Delete(productToDelete.ProductId);

            // Assert
            productRepoMock.Verify(m => m.DeleteProduct(productToDelete.ProductId));
        }
    }
}
