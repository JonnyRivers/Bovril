using System;
using System.Web.Mvc;

using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const String c_sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext modelBindingContext)
        {
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[c_sessionKey];
            }

            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[c_sessionKey] = cart;
                }
            }

            return cart;
        }
    }
}