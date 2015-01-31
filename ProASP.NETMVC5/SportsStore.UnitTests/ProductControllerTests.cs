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
    public class ProductControllerTests
    {
        [TestMethod]
        public void TestPaginationViewModel()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            });

            ProductController controller = new ProductController(mockBuilder.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel page2ViewModel = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            PagingInfo pagingInfo = page2ViewModel.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 3);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }

        [TestMethod]
        public void TestPagination()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            });

            ProductController controller = new ProductController(mockBuilder.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel page1ViewModel = (ProductsListViewModel)controller.List(null, 1).Model;
            ProductsListViewModel page2ViewModel = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            Product[] page1Products = page1ViewModel.Products.ToArray();
            Assert.IsTrue(page1Products.Length == 3);
            Assert.AreEqual(page1Products[0].ProductId, 1);
            Assert.AreEqual(page1Products[1].ProductId, 2);
            Assert.AreEqual(page1Products[2].ProductId, 3);
            Assert.AreEqual(page1Products[0].Name, "P1");
            Assert.AreEqual(page1Products[1].Name, "P2");
            Assert.AreEqual(page1Products[2].Name, "P3");

            Product[] page2Products = page2ViewModel.Products.ToArray();
            Assert.IsTrue(page2Products.Length == 2);
            Assert.AreEqual(page2Products[0].ProductId, 4);
            Assert.AreEqual(page2Products[1].ProductId, 5);
            Assert.AreEqual(page2Products[0].Name, "P4");
            Assert.AreEqual(page2Products[1].Name, "P5");
        }

        [TestMethod]
        public void TestProductFiltering()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductId = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "P5", Category = "Cat3"}
            });

            ProductController controller = new ProductController(mockBuilder.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel category1ViewModel = (ProductsListViewModel)controller.List("Cat1", 1).Model;
            ProductsListViewModel category2ViewModel = (ProductsListViewModel)controller.List("Cat2", 1).Model;
            ProductsListViewModel category3ViewModel = (ProductsListViewModel)controller.List("Cat3", 1).Model;

            // Assert
            Product[] category1Products = category1ViewModel.Products.ToArray();
            Assert.IsTrue(category1Products.Length == 2);
            Assert.AreEqual(category1Products[0].ProductId, 1);
            Assert.AreEqual(category1Products[1].ProductId, 3);
            Assert.AreEqual(category1Products[0].Name, "P1");
            Assert.AreEqual(category1Products[1].Name, "P3");

            Product[] category2Products = category2ViewModel.Products.ToArray();
            Assert.IsTrue(category2Products.Length == 2);
            Assert.AreEqual(category2Products[0].ProductId, 2);
            Assert.AreEqual(category2Products[1].ProductId, 4);
            Assert.AreEqual(category2Products[0].Name, "P2");
            Assert.AreEqual(category2Products[1].Name, "P4");

            Product[] category3Products = category3ViewModel.Products.ToArray();
            Assert.IsTrue(category3Products.Length == 1);
            Assert.AreEqual(category3Products[0].ProductId, 5);
            Assert.AreEqual(category3Products[0].Name, "P5");
        }

        [TestMethod]
        public void TestCategorySpecificProductCount()
        {
            // Arrange
            Mock<IProductRepository> mockBuilder = new Mock<IProductRepository>();
            mockBuilder.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductId = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "P5", Category = "Cat3"}
            });

            ProductController controller = new ProductController(mockBuilder.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel allCategoriesViewModel = (ProductsListViewModel)controller.List(null).Model;
            ProductsListViewModel category1ViewModel = (ProductsListViewModel)controller.List("Cat1").Model;
            ProductsListViewModel category2ViewModel = (ProductsListViewModel)controller.List("Cat2").Model;
            ProductsListViewModel category3ViewModel = (ProductsListViewModel)controller.List("Cat3").Model;

            int numItemsAll = allCategoriesViewModel.PagingInfo.TotalItems;
            int numItemsCat1 = category1ViewModel.PagingInfo.TotalItems;
            int numItemsCat2 = category2ViewModel.PagingInfo.TotalItems;
            int numItemsCat3 = category3ViewModel.PagingInfo.TotalItems;

            // Assert
            Assert.AreEqual(numItemsAll, 5);
            Assert.AreEqual(numItemsCat1, 2);
            Assert.AreEqual(numItemsCat2, 2);
            Assert.AreEqual(numItemsCat3, 1);
        }
    }
}
