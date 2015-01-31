using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using EssentialTools.Models;

namespace EssentialTools.Tests
{
    [TestClass]
    public class DefaultDiscounterTests
    {
        private Product[] m_products = {
            new Product {Name="Kayak", Category="Watersports", Price=275M},
            new Product {Name="Lifejacket", Category="Watersports", Price=48.95M},
            new Product {Name="Soccer ball", Category="Soccer", Price=19.50M},
            new Product {Name="Corner flag", Category="Soccer", Price=34.95M}
        };

        private IDiscounter getTestObject()
        {
            return new DefaultDiscounter(0.8M);
        }

        [TestMethod]
        public void TestApplyDiscount()
        {
            IDiscounter target = getTestObject();
            decimal total = 100M;

            var discountedTotal = target.ApplyDiscount(total);

            Assert.AreEqual(total * 0.8M, discountedTotal);
        }

        [TestMethod]
        public void TestComplexMockImplementation()
        {
            Mock<IDiscounter> mock = new Mock<IDiscounter>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(total => total - 5);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100)))
                .Returns<decimal>(total => total * 0.9M);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v < 0)))
                .Throws<System.ArgumentOutOfRangeException>();

            var target = new LinqValueCalculator(mock.Object);

            var result = target.ValueProducts(m_products);

            Assert.AreEqual(m_products.Sum(e => e.Price) * 0.9M, result);
        }
    }
}
