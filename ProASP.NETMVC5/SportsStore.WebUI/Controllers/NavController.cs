using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using SportsStore.Domain.Abstract;

using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository m_repository;

        public NavController(IProductRepository repository)
        {
            m_repository = repository;
        }
        // GET: Nav
        public PartialViewResult Menu(String category = null)
        {
            NavViewModel viewModel = new NavViewModel
            {
                Categories = m_repository.Products
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x),
                SelectedCategory = category
            };

            return PartialView(viewModel);
        }
    }
}