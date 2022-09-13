using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IReservationDB
    {
        int AddReservation(Reservation re);
        int DeleteReservation(Reservation re);
        Reservation GetReservation(int idReservation);
        List<Reservation> GetReservations();
        int UpdateReservation(Reservation re, string firstname, string lastname);
    }
}