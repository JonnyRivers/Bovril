using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.Sakila.ConsumerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var filmServiceClient = new FilmServiceReference.FilmServiceClient();
            FilmServiceReference.Film[] films = filmServiceClient.GetAllFilms();
            stopwatch.Stop();
            foreach (FilmServiceReference.Film film in films)
            {
                Console.WriteLine("FilmId={0}, Title={1}, Description={2}", film.FilmId, film.Title, film.Description);
            }
            Console.WriteLine("Num films = {0} after {1}", films.Count(), stopwatch.Elapsed);
        }
    }
}
