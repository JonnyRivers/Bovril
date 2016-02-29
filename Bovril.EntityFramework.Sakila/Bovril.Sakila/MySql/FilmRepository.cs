using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.Sakila.MySql
{
    internal class FilmRepository : IFilmRepository
    {
        public IEnumerable<IFilm> GetAllFilms()
        {
            using (var context = new Bovril.EntityFramework.Sakila.sakilaEntities())
            {
                Bovril.EntityFramework.Sakila.film[] dbFilms = context.films.ToArray();
                return dbFilms.Select(dbFilm => new Film(dbFilm)).ToArray();
            }
        }
    }
}
