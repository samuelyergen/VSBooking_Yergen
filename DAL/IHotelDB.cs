using DTO;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IHotelDB
    {
        Hotel GetHotel(string name);
        Hotel GetHotelById(int id);
        List<Hotel> GetHotels();
        List<Hotel> GetHotelsAdvancedSearch(string location, string category, string hasParking, string hasWifi);
        List<Hotel> GetHotelsByLocation(string location, string searchDateStartString, string searchDateEndString);
        List<Hotel> GetHotelsWithDate(string location, DateTime dateStart, DateTime dateEnd);
    }
}