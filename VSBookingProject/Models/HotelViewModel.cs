using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace VSBookingProject.Models
{
    public class HotelViewModel
    {

        public Hotel Hotel { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
