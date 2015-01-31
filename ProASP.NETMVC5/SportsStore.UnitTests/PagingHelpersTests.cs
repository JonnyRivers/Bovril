using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class PagingHelpersTests
    {
        [TestMethod]
        public void TestPageLinks()
        {
            HtmlHelper htmlHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            Func<int, String> pageUrlDelegate = i => "Page" + i;

            MvcHtmlString result = htmlHelper.PageLinks(pagingInfo, pageUrlDelegate);

            String expectedHtml = @"<a class=""btn btn-default"" href=""Page1"">1</a>" +
                @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" +
                @"<a class=""btn btn-default"" href=""Page3"">3</a>";
            Assert.AreEqual(expectedHtml, result.ToString());
        }
    }
}
