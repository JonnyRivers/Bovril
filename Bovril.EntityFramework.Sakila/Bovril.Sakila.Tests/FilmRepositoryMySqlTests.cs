using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bovril.Sakila.Tests
{
    [TestClass]
    public class FilmRepositoryMySqlTests
    {
        [TestMethod]
        public void TestGetAllFilms()
        {
            // Arrange
            IFilmRepository filmRepository = Bovril.Sakila.RepositoryFactory.CreateFilmRepositoryMySql();

            // Act
            IEnumerable<IFilm> films = filmRepository.GetAllFilms();

            // Assert
            Assert.AreEqual(1000, films.Count());
        }
    }
}
