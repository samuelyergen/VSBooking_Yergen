using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Booking
    {
        public int IdRoom { get; set; }
        public int IdReservation { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }


        public override string ToString()
        {
            return "Id room: " + IdRoom +
                    "Id reservation: " + IdReservation +
                    "From: " + DateStart +
                    "To: " + DateEnd; 
        }

    }
}
