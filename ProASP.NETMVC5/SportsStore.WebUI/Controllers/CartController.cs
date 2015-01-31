using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository m_repository;
        private IOrderProcessor m_orderProcessor;

        public CartController(IProductRepository repository, IOrderProcessor orderProcessor)
        {
            m_repository = repository;
            m_orderProcessor = orderProcessor;
        }

        // JWR: cart is passed through courtesy of CartModelBinder, which is configured in Global.asax
        public ViewResult Index(Cart cart, String returnUrl)
        {
            return View(new CartIndexViewModel {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        
        public RedirectToRouteResult AddToCart(Cart cart, int productId, String returnUrl)
        {
            Product product = m_repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null) {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, String returnUrl)
        {
            Product product = m_repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null) {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if(ModelState.IsValid)
            {
                m_orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}