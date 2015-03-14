using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServices.Models
{
    public class ReservationRepository
    {
        private static ReservationRepository s_repository;

        public static ReservationRepository Current
        {
            get
            {
                if (s_repository == null)
                    s_repository = new ReservationRepository();

                return s_repository;
            }
        }

        private List<Reservation> m_data = new List<Reservation>
        {
            new Reservation{
                ReservationId = 1, ClientName = "Adam", Location = "Board Room"
            },
            new Reservation{
                ReservationId = 2, ClientName = "Jacqui", Location = "Lecture Hall"
            },
            new Reservation{
                ReservationId = 3, ClientName = "Russell", Location = "Meeting Room 1"
            }
        };

        public IEnumerable<Reservation> GetAll()
        {
            return m_data;
        }

        public Reservation Get(int id)
        {
            return m_data.FirstOrDefault(r => r.ReservationId == id);
        }

        public Reservation Add(Reservation item)
        {
            item.ReservationId = m_data.Max(r => r.ReservationId) + 1;
            m_data.Add(item);

            return item;
        }

        public void Remove(int id)
        {
            Reservation item = Get(id);
            if (item != null)
            {
                m_data.Remove(item);
            }
        }

        public bool Update(Reservation item)
        {
            Reservation storedItem = Get(item.ReservationId);
            if (storedItem != null)
            {
                storedItem.ClientName = item.ClientName;
                storedItem.Location = item.Location;

                return true;
            }

            return false;
        }
    }
}