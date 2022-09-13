using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;

namespace BLL
{
    public class BookingManager : IBookingManager
    {

        private IBookingDB BookingDB { get; }

        public BookingManager(IBookingDB bookingDB)
        {
            BookingDB = bookingDB;
        }

        public List<Booking> GetBooking(int idReservation)
        {
            return BookingDB.GetBooking(idReservation);
        }

        public int AddBooking(int idReservation, int idRoom, DateTime dateStart, DateTime dateEnd)
        {
            return BookingDB.AddBooking(idReservation, idRoom, dateStart, dateEnd);
        }

        public int DeleteBooking(Reservation re)
        {
            return BookingDB.DeleteBooking(re);
        }

        public int UpdateRoomBooking(Reservation re, Room r, Room rr, DateTime dateStart, DateTime dateEnd)
        {
            return BookingDB.UpdateRoomBooking(re, r, rr, dateStart, dateEnd);
        }

        public int UpdateDateBooking(Reservation re, Room r, DateTime dateStart, DateTime dateEnd)
        {
            return BookingDB.UpdateDateBooking(re, r, dateStart, dateEnd);
        }
    }
}
