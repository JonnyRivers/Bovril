using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> m_cartLines = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            var cartLineQuery = m_cartLines.Where(p => p.Product.ProductId == product.ProductId);
            if (cartLineQuery.Any()) {
                cartLineQuery.First().Quantity += quantity;
            }
            else {
                m_cartLines.Add(new CartLine { Product = product, Quantity = quantity });
            }
        }

        public void RemoveLine(Product product)
        {
            m_cartLines.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return m_cartLines.Sum(l => l.Product.Price * l.Quantity);
        }

        public void Clear()
        {
            m_cartLines.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return m_cartLines; }
        }
    }
}
