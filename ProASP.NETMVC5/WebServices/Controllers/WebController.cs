using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebServices.Models;

namespace WebServices.Controllers
{
    public class WebController : ApiController
    {
        public IEnumerable<Reservation> GetAllReservations()
        {
            return ReservationRepository.Current.GetAll();
        }

        public Reservation GetReservation(int id)
        {
            return ReservationRepository.Current.Get(id);
        }

        //public Reservation PostReservation(Reservation item)
        [HttpPost]
        public Reservation CreateReservation(Reservation item)
        {
            return ReservationRepository.Current.Add(item);
        }

        //public bool PutReservation(Reservation item)
        [HttpPut]
        public bool UpdateReservation(Reservation item)
        {
            return ReservationRepository.Current.Update(item);
        }

        public void DeleteReservation(int id)
        {
            ReservationRepository.Current.Remove(id);
        }
    }
}
