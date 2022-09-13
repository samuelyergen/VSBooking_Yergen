using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using DAL;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using DTO;


namespace VSBookingConsole
{
    class Program
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();
        static void Main(string[] args)
        {
            /*
            var hotelManager = new HotelManager(Configuration);
            
            Hotel hotel = hotelManager.GetHotel("Yo");
            

            Console.WriteLine(hotel);*/

            var hotelDB = new HotelDB(Configuration);

            Hotel h = hotelDB.GetHotel("HotelH");
            
            
            var reservationDB = new ReservationDB(Configuration);

            Reservation re = reservationDB.GetReservation(3, "Chris", "Reifert");
            //reservationDB.UpdateReservation(re, "Chris", "Reifert");
            
            var roomDB = new RoomDB(Configuration);
            Room r = roomDB.GetRoom(h, 4);

            var pictureDB = new PictureDB(Configuration);
            Picture p = new Picture();
            p.Url = "blublublu.com/blu";
            string ur = "blobloblo.com/bloblo";
            pictureDB.UpdatePicture(r, 2, ur);
            //pictureDB.AddPicture(p, r);

            var bookingDB = new BookingDB(Configuration);
            DateTime from = new DateTime(2020, 11, 12,12,0,0);
            DateTime to = new DateTime(2020, 11, 15,12,0,0);
            //bookingDB.AddBooking(re, r, from, to);
            //bookingDB.DeleteBooking(re);
            bookingDB.UpdateDateBooking(re, r, from, to);

            //var roomDB = new RoomDB(Configuration);

            //Room r = roomDB.GetRoom(h, 4);

            

            //reservationDB.DeleteReservation(2, "Scott", "Carlson");
            
            /*
            r.HasHairDryer = true;
            r.HasTv = true;
            r.Number = 4;
            r.Price = 150;
            r.Type = 2;
            r.Description = "blabla";

            Room room = roomDB.AddRoom(r, h);
            */

            //roomDB.DeleteRoom(roomDB.GetRoom(h, 4));


        }
    }
}
