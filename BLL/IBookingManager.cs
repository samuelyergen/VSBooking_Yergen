using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public interface IBookingManager
    {
        int AddBooking(int idReservation, int idRoom, DateTime dateStart, DateTime dateEnd);
        int DeleteBooking(Reservation re);
        List<Booking> GetBooking(int idReservation);
        int UpdateDateBooking(Reservation re, Room r, DateTime dateStart, DateTime dateEnd);
        int UpdateRoomBooking(Reservation re, Room r, Room rr, DateTime dateStart, DateTime dateEnd);
    }
}