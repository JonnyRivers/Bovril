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
    public class CartTests
    {
        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };

            Cart cart = new Cart();

            // Act
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p1, 10);

            // Assert
            CartLine[] cartLines = cart.Lines.OrderBy(l => l.Product.ProductId).ToArray();
            Assert.AreEqual(cartLines.Length, 2);
            Assert.AreEqual(cartLines[0].Quantity, 11);
            Assert.AreEqual(cartLines[1].Quantity, 1);
        }

        [TestMethod]
        public void TestRemove()
        {
            // Arrange
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };
            Product p3 = new Product { ProductId = 3, Name = "P3" };

            Cart cart = new Cart();

            // Act
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p3, 1);
            cart.AddItem(p2, 4);
            cart.AddItem(p1, 7);

            cart.RemoveLine(p2);

            // Assert
            Assert.AreEqual(cart.Lines.Where(l => l.Product == p2).Any(), false);
            Assert.AreEqual(cart.Lines.Count(), 2);
        }

        [TestMethod]
        public void TestComputeTotalValue()
        {
            // Arrange
            Product p1 = new Product { ProductId = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductId = 2, Name = "P2", Price = 50M };

            Cart cart = new Cart();

            // Act
            decimal initialTotalValue = cart.ComputeTotalValue();
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p1, 3);
            decimal finalTotalValue = cart.ComputeTotalValue();

            // Assert
            Assert.AreEqual(initialTotalValue, 0);
            Assert.AreEqual(finalTotalValue, 450M);
        }

        [TestMethod]
        public void TestClear()
        {
            // Arrange
            Product p1 = new Product { ProductId = 1, Name = "P1" };
            Product p2 = new Product { ProductId = 2, Name = "P2" };

            Cart cart = new Cart();

            // Act
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p1, 10);
            cart.Clear();

            // Assert
            Assert.AreEqual(cart.Lines.Count(), 0);
        }
    }
}
