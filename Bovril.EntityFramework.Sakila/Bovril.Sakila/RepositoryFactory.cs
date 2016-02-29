using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.Sakila
{
    public static class RepositoryFactory
    {
        public static IFilmRepository CreateFilmRepositoryMySql()
        {
            return new MySql.FilmRepository();
        }
    }
}
