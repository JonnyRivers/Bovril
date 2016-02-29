using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bovril.EntityFramework.Sakila.Tests
{
    [TestClass]
    public class SakilaTests
    {
        [TestMethod]
        public void TestGetFilms()
        {
            using(Bovril.EntityFramework.Sakila.sakilaEntities context = new sakilaEntities()) {
                Bovril.EntityFramework.Sakila.film[] films = context.films.ToArray();
            }
            
        }
    }
}
