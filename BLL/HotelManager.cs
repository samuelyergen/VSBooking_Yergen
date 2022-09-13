
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;


namespace BLL
{
    public class HotelManager : IHotelManager
    {
        private IHotelDB HotelDB { get; }

        public HotelManager(IHotelDB hotelDb)
        {
            HotelDB = hotelDb;
        }

        public List<Hotel> GetHotels()
        {
            return HotelDB.GetHotels();
        }

        public Hotel GetHotel(string name)
        {
            return HotelDB.GetHotel(name);
        }

        public List<Hotel> GetHotelsByLocation(string location, string searchDateStartString, string searchDateEndString)
        {
            return HotelDB.GetHotelsByLocation(location, searchDateStartString, searchDateEndString);
        }

        public Hotel GetHotelById(int id)
        {
            return HotelDB.GetHotelById(id);
        }

        public List<Hotel> GetHotelsWithDate(string location, DateTime dateStart, DateTime dateEnd)
        {
            return HotelDB.GetHotelsWithDate(location, dateStart, dateEnd);
        }

        public List<Hotel> GetHotelsAdvancedSearch(string location, string category, string hasParking, string hasWifi)
        {
            return HotelDB.GetHotelsAdvancedSearch(location, category, hasParking, hasWifi);
        }

    }


}
