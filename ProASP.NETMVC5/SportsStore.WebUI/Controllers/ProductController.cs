using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository m_productRepository;

        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            m_productRepository = productRepository;
        }

        public ViewResult List(String category, int page = 1)
        {
            int totalItems;
            if (category == null) {
                totalItems = m_productRepository.Products.Count();
            }
            else {
                totalItems = m_productRepository.Products.Where(e => e.Category == category).Count();
            }

            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                Products = m_productRepository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = totalItems
                },
                CurrentCategory = category
            };

            return View(viewModel);
        }

        public FileContentResult GetImage(int productId)
        {
            Product product = m_productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}