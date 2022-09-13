using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class ReservationManager : IReservationManager
    {

        private IReservationDB ReservationDB { get; }
        private IBookingDB BookingDB { get; }

        public ReservationManager(IReservationDB reservationDB, IBookingDB bookingDB)
        {
            ReservationDB = reservationDB;
            BookingDB = bookingDB;
        }


        public List<Reservation> GetReservations()
        {
            return ReservationDB.GetReservations();
        }

        public Reservation GetReservation(int idReservation)
        {      
            return ReservationDB.GetReservation(idReservation);
        }

        public int AddReservation(Reservation re)
        {
           
            return ReservationDB.AddReservation(re);
        }

        public int DeleteReservation(Reservation re)
        {
            BookingDB.DeleteBooking(re);
            return ReservationDB.DeleteReservation(re);
        }

        public int UpdateReservation(Reservation re, string firstname, string lastname)
        {
            return ReservationDB.UpdateReservation(re, firstname, lastname);
        }
    }
}
