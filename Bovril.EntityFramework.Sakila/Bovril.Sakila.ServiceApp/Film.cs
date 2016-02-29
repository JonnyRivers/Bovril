using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace Bovril.Sakila.ServiceApp
{
    [DataContract]
    public class Film
    {
        public Film(IFilm film)
        {
            FilmId = film.FilmId;
            Title = film.Title;
            Description = film.Description;
        }

        [DataMember]
        public int FilmId;

        [DataMember]
        public String Title;

        [DataMember]
        public String Description;
    }
}