using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bovril.Sakila.MySql
{
    internal class Film : IFilm
    {
        private readonly int m_filmId;
        private readonly String m_title;
        private readonly String m_description;

        public int FilmId
        {
            get { return m_filmId; }
        }

        public string Title
        {
            get { return m_title; }
        }

        public string Description
        {
            get { return m_description; }
        }

        internal Film(Bovril.EntityFramework.Sakila.film film) {
            m_filmId = film.film_id;
            m_title = film.title;
            m_description = film.description;
        }
    }
}

