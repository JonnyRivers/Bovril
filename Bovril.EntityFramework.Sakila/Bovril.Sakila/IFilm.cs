using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.Sakila
{
    public interface IFilm
    {
        int FilmId { get; }
        String Title { get; }
        String Description { get; }
    }
}
