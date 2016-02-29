using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Bovril.Sakila.ServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FilmService : IFilmService
    {
        public int GetNumFilms()
        {
            IFilmRepository filmRepository = Bovril.Sakila.RepositoryFactory.CreateFilmRepositoryMySql();

            return filmRepository.GetAllFilms().Count();
        }


        public Film[] GetAllFilms()
        {
            IFilmRepository filmRepository = Bovril.Sakila.RepositoryFactory.CreateFilmRepositoryMySql();

            return filmRepository.GetAllFilms().Select(film => new Film(film)).ToArray();
        }
    }
}
