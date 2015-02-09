using System;
using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ControllersAndActions.Controllers;

namespace ControllersAndActions.Tests
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void ControllerTest()
        {
            // Arrange
            ExampleController exampleController = new ExampleController();

            ViewResult result = exampleController.Index();

            Assert.AreEqual("", result.ViewName);
            Assert.IsInstanceOfType(result.ViewData.Model, typeof(System.DateTime));
        }
    }
}
