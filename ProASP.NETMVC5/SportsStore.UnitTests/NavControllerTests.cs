using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class NavControllerTests
    {
        [TestMethod]
        public void TestCategories()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Apples"},
                new Product {ProductId = 2, Name = "P2", Category = "Apples"},
                new Product {ProductId = 3, Name = "P3", Category = "Plums"},
                new Product {ProductId = 4, Name = "P4", Category = "Oranges"}
            });

            NavController controller = new NavController(mockBuilder.Object);

            // Act
            NavViewModel viewModel = (NavViewModel)controller.Menu().Model;

            // Assert
            String[] categories = viewModel.Categories.ToArray();
            Assert.AreEqual(categories.Length, 3);
            Assert.AreEqual(categories[0], "Apples");
            Assert.AreEqual(categories[1], "Oranges");
            Assert.AreEqual(categories[2], "Plums");
        }

        [TestMethod]
        public void TestCategorySelection()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Apples"},
                new Product {ProductId = 2, Name = "P2", Category = "Apples"},
                new Product {ProductId = 3, Name = "P3", Category = "Plums"},
                new Product {ProductId = 4, Name = "P4", Category = "Oranges"}
            });

            NavController controller = new NavController(mockBuilder.Object);
            String categoryToSelect = "Apples";

            // Act
            NavViewModel viewModel = (NavViewModel)controller.Menu(categoryToSelect).Model;

            // Assert
            Assert.AreEqual(viewModel.SelectedCategory, categoryToSelect);
        }
    }
}

