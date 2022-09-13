using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }


        public override string ToString()
        {
            return "Id reservation: " + IdReservation +
                    "Firstname: " + Firstname +
                    "Lastname: " + Lastname;

        }
    }
}
