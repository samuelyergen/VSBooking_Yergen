using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RoomManager : IRoomManager
    {

        private IRoomDB RoomDB { get; }

        public RoomManager(IRoomDB roomDB)
        {
            RoomDB = roomDB;
        }

        public List<Room> GetRooms(Hotel h)
        {
            return RoomDB.GetRooms(h);
        }

        public Room GetRoom(Hotel h, int number)
        {
            return RoomDB.GetRoom(h, number);
        }

        public int DeleteRoom(Room r)
        {
            return RoomDB.DeleteRoom(r);
        }

        public int UpdateRoom(Room r, int number, string description, int type, double price, Boolean hasTv, Boolean hasHairDryer)
        {
            return RoomDB.UpdateRoom(r, number, description, type, price, hasTv, hasHairDryer);
        }

        public List<Room> GetRoomsByIdHotel(int id)
        {
            return RoomDB.GetRoomsByIdHotel(id);
        }

        public Room GetRoomById(int id)
        {
            return RoomDB.GetRoomById(id);
        }

        public List<Room> GetRoomsByIdHotelAndDate(int id, DateTime dStart, DateTime dEnd)
        {
            return RoomDB.GetRoomsByIdHotelAndDate(id, dStart, dEnd);
        }

        public List<Room> GetRoomsAdvancedSearch(int id, string searchDateStart, string searchDateEnd, string price, string hasHairDryer, string hasTv, string type)
        {
            return RoomDB.GetRoomsAdvancedSearch(id, searchDateStart, searchDateEnd, price, hasHairDryer, hasTv, type);
        }

        public int CountRoom(int id)
        {
            return RoomDB.CountRoom(id);
        }

        public int CountRoomWithDate(int id, string dateStart, string dateEnd)
        {
            return RoomDB.CountRoomWithDate(id, dateStart, dateEnd);
        }
    }
}
