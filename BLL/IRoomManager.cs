using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public interface IRoomManager
    {
        int CountRoom(int id);
        int CountRoomWithDate(int id, string dateStart, string dateEnd);
        int DeleteRoom(Room r);
        Room GetRoom(Hotel h, int number);
        Room GetRoomById(int id);
        List<Room> GetRooms(Hotel h);
        List<Room> GetRoomsAdvancedSearch(int id, string searchDateStart, string searchDateEnd, string price, string hasHairDryer, string hasTv, string type);
        List<Room> GetRoomsByIdHotel(int id);
        List<Room> GetRoomsByIdHotelAndDate(int id, DateTime dStart, DateTime dEnd);
        int UpdateRoom(Room r, int number, string description, int type, double price, bool hasTv, bool hasHairDryer);
    }
}