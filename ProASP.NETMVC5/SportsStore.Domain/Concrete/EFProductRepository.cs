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
    }
}
