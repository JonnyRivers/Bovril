using System;
using System.Collections.Generic;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext m_context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return m_context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                m_context.Products.Add(product);
            }
            else
            {
                Product dbEntry = m_context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }
            m_context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            Product dbEntry = m_context.Products.Find(productId);
            if (dbEntry != null)
            {
                m_context.Products.Remove(dbEntry);
                m_context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
