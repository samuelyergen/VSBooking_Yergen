using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DAL
{
    public class RoomDB : IRoomDB
    {

        private string ConnectionString = null;
        

        public RoomDB(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("MyConnection");
        }

        /// <summary>
        /// Get all the rooms of an hotel
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public List<Room> GetRooms(Hotel h)
        {
            if (h == null)
            {
                Console.WriteLine("hotel empty");
                return null;
            }

            List<Room> rooms = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "select * from Room where IdHotel = @IdHotel";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", h.IdHotel);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (rooms == null)
                                rooms = new List<Room>();

                            Room r = new Room();

                            r.IdRoom = (int)dr["IdRoom"];

                            if (dr["Number"] != DBNull.Value)
                                r.Number = (int)dr["Number"];

                            if (dr["Description"] != DBNull.Value)
                                r.Description = (string)dr["Description"];

                            if (dr["Type"] != DBNull.Value)
                                r.Type = (int)dr["Type"];

                            if (dr["Price"] != DBNull.Value)
                                r.Price = (double)dr["Price"];

                            if (dr["HasTv"] != DBNull.Value)
                                r.HasTv = (bool)dr["HasTv"];

                            if (dr["HasHairDryer"] != DBNull.Value)
                                r.HasHairDryer = (bool)dr["HasHairDryer"];

                            rooms.Add(r);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rooms;
        }

        /// <summary>
        /// Get a specific room of a specific hotel
        /// </summary>
        /// <param name="h"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public Room GetRoom(Hotel h, int number)
        {

            if (h == null)
            {
                Console.WriteLine("hotel empty");
                return null;
            }


            Room r = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "select * from Room where IdHotel = @IdHotel and Number = @Number";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", h.IdHotel);
                    cmd.Parameters.AddWithValue("@Number", number);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            r = new Room();

                            r.IdRoom = (int)dr["IdRoom"];

                            if (dr["Number"] != DBNull.Value)
                                r.Number = (int)dr["Number"];

                            if (dr["Description"] != DBNull.Value)
                                r.Description = (string)dr["Description"];

                            if (dr["Type"] != DBNull.Value)
                                r.Type = (int)dr["Type"];

                            if (dr["Price"] != DBNull.Value)
                                r.Price = (double)dr["Price"];

                            if (dr["HasTv"] != DBNull.Value)
                                r.HasTv = (bool)dr["HasTv"];

                            if (dr["HasHairDryer"] != DBNull.Value)
                                r.HasHairDryer = (bool)dr["HasHairDryer"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur de connection");

            }
            return r;
        }

        /// <summary>
        /// Add a room in a hotel
        /// </summary>
        /// <param name="r"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public Room AddRoom(Room r, Hotel h)
        {

            if (r == null || h == null)
            {
                Console.WriteLine("room or hotel empty");
                return null;
            }

            

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "insert into Room(Number, Description, Type, Price, HasTv, HasHairDryer, IdHotel) values(@Number, @Description, @Type, @Price, @HasTv, @HasHairDryer, @IdHotel); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Number", r.Number);
                    cmd.Parameters.AddWithValue("@Description", r.Description);
                    cmd.Parameters.AddWithValue("@Type", r.Type);
                    cmd.Parameters.AddWithValue("@Price", r.Price);
                    cmd.Parameters.AddWithValue("@HasTv", r.HasTv);
                    cmd.Parameters.AddWithValue("@HasHairDryer", r.HasHairDryer);
                    cmd.Parameters.AddWithValue("@IdHotel", h.IdHotel);


                    cn.Open();

                    r.IdRoom = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return r;
        }

        /// <summary>
        /// Delete a room
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public int DeleteRoom(Room r)
        {

            if (r == null)
            {
                Console.WriteLine("room empty");
                return 0;
            }

            int result = 0;

            

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "delete Room where IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur de connection");

            }
            return result;
        }

        /// <summary>
        /// Can update each attributes of a room
        /// </summary>
        /// <param name="r"></param>
        /// <param name="number"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="price"></param>
        /// <param name="hasTv"></param>
        /// <param name="hasHairDryer"></param>
        /// <returns></returns>
        public int UpdateRoom(Room r, int number, string description, int type, double price, bool hasTv, bool hasHairDryer)
        {

            if (r == null)
            {
                Console.WriteLine("Erreur de connection");
                return 0;
            }

            int result = 0;
            
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "update Room set Number = @Number, Description = @Description, Type = @Type, Price = @Price, HasTv = @HasTv, HasHairDryer = @HasHairDryer where IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Number", number);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@HasTv", hasTv);
                    cmd.Parameters.AddWithValue("@HasHairDryer", hasHairDryer);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return result;
        }
        /// <summary>
        /// Get all the rooms of a specific hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Room> GetRoomsByIdHotel(int id)
        {


            List<Room> rooms = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {


                    string query = "select * from Room where IdHotel = @IdHotel";
                    string query2 = "select * from Room " +
                        "WHERE IdRoom NOT IN (select r.IdRoom from Booking as b " +
                        "INNER JOIN Room as r ON r.IdRoom = b.IdRoom " +
                        "AND b.DateStart >= @DateStart " +
                        "AND b.DateEnd <= @DateEnd";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (rooms == null)
                                rooms = new List<Room>();

                            Room r = new Room();

                            r.IdRoom = (int)dr["IdRoom"];

                            if (dr["Number"] != DBNull.Value)
                                r.Number = (int)dr["Number"];

                            if (dr["Description"] != DBNull.Value)
                                r.Description = (string)dr["Description"];

                            if (dr["Type"] != DBNull.Value)
                                r.Type = (int)dr["Type"];

                            if (dr["Price"] != DBNull.Value)
                                r.Price = (double)dr["Price"];

                            if (dr["HasTv"] != DBNull.Value)
                                r.HasTv = (bool)dr["HasTv"];

                            if (dr["HasHairDryer"] != DBNull.Value)
                                r.HasHairDryer = (bool)dr["HasHairDryer"];

                            rooms.Add(r);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rooms;
        }

        /// <summary>
        /// get a room by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Room GetRoomById(int id)
        {

            Room r = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "select * from Room where IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            r = new Room();

                            r.IdRoom = (int)dr["IdRoom"];

                            if (dr["Number"] != DBNull.Value)
                                r.Number = (int)dr["Number"];

                            if (dr["Description"] != DBNull.Value)
                                r.Description = (string)dr["Description"];

                            if (dr["Type"] != DBNull.Value)
                                r.Type = (int)dr["Type"];

                            if (dr["Price"] != DBNull.Value)
                                r.Price = (double)dr["Price"];

                            if (dr["HasTv"] != DBNull.Value)
                                r.HasTv = (bool)dr["HasTv"];

                            if (dr["HasHairDryer"] != DBNull.Value)
                                r.HasHairDryer = (bool)dr["HasHairDryer"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return r;
        }

        /// <summary>
        /// Get rooms by hotel during a specific amount of time
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dStart"></param>
        /// <param name="dEnd"></param>
        /// <returns></returns>
        public List<Room> GetRoomsByIdHotelAndDate(int id, DateTime dStart, DateTime dEnd)
        {


            List<Room> rooms = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {

                    string query = "select * from Room " +
                        "WHERE IdHotel = @IdHotel " +
                        "AND IdRoom NOT IN (select r.IdRoom from Booking as b " +
                        "INNER JOIN Room as r ON r.IdRoom = b.IdRoom " +
                        "AND b.DateStart >= @DateStart " +
                        "AND b.DateEnd <= @DateEnd)";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DateStart", dStart);
                    cmd.Parameters.AddWithValue("@DateEnd", dEnd);
                    cmd.Parameters.AddWithValue("@IdHotel", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (rooms == null)
                                rooms = new List<Room>();

                            Room r = new Room();

                            r.IdRoom = (int)dr["IdRoom"];

                            if (dr["Number"] != DBNull.Value)
                                r.Number = (int)dr["Number"];

                            if (dr["Description"] != DBNull.Value)
                                r.Description = (string)dr["Description"];

                            if (dr["Type"] != DBNull.Value)
                                r.Type = (int)dr["Type"];

                            if (dr["Price"] != DBNull.Value)
                                r.Price = (double)dr["Price"];

                            if (dr["HasTv"] != DBNull.Value)
                                r.HasTv = (bool)dr["HasTv"];

                            if (dr["HasHairDryer"] != DBNull.Value)
                                r.HasHairDryer = (bool)dr["HasHairDryer"];

                            rooms.Add(r);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rooms;
        }
        /// <summary>
        /// Used for advanced search for the rooms
        /// take all the filters in parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="searchDateStart"></param>
        /// <param name="searchDateEnd"></param>
        /// <param name="price"></param>
        /// <param name="hasHairDryer"></param>
        /// <param name="hasTv"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Room> GetRoomsAdvancedSearch(int id, string searchDateStart, string searchDateEnd, string price, string hasHairDryer, string hasTv, string type)
        {
            DateTime ds = new DateTime();
            DateTime de = new DateTime();
            int p = new int();
            bool hhd = new bool();
            bool ht = new bool();
            int t = new int();

            List<Room> rooms = null;

            if (searchDateStart != null)
                ds = DateTime.ParseExact(searchDateStart, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (searchDateEnd != null)
                de = DateTime.ParseExact(searchDateEnd, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (price != null)
                p = int.Parse(price);

            if (hasHairDryer != null)
                hhd = bool.Parse(hasHairDryer);

            if (hasTv != null)
                ht = bool.Parse(hasTv);

            if (type != null)
                t = int.Parse(type);



            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {



                    string query = "select * from Room " +
                        "WHERE IdHotel = @IdHotel ";

                    if (price != null)
                        query += "AND Price <= @Price ";

                    if (hasHairDryer != null)
                        query += "AND HasHairDryer = @HasHairDryer ";

                    if (hasTv != null)
                        query += "AND HasTv = @HasTv ";

                    if (type != null)
                        query += "AND Type = @Type ";

                    if (searchDateStart != null && searchDateEnd != null)
                        query += "AND IdRoom NOT IN (select r.IdRoom from Booking as b " +
                        "INNER JOIN Room as r ON r.IdRoom = b.IdRoom " +
                        "AND b.DateStart >= @DateStart " +
                        "AND b.DateEnd <= @DateEnd)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", id);
                    if (price != null)
                        cmd.Parameters.AddWithValue("@Price", p);
                    if (type != null)
                        cmd.Parameters.AddWithValue("@Type", t);
                    if (hasHairDryer != null)
                        cmd.Parameters.AddWithValue("@HasHairDryer", hhd);
                    if (hasTv != null)
                        cmd.Parameters.AddWithValue("@HasTv", ht);
                    if (searchDateStart != null)
                        cmd.Parameters.AddWithValue("@DateStart", ds);
                    if (searchDateEnd != null)
                        cmd.Parameters.AddWithValue("@DateEnd", de);



                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (rooms == null)
                                rooms = new List<Room>();

                            Room r = new Room();

                            r.IdRoom = (int)dr["IdRoom"];

                            if (dr["Number"] != DBNull.Value)
                                r.Number = (int)dr["Number"];

                            if (dr["Description"] != DBNull.Value)
                                r.Description = (string)dr["Description"];

                            if (dr["Type"] != DBNull.Value)
                                r.Type = (int)dr["Type"];

                            if (dr["Price"] != DBNull.Value)
                                r.Price = (double)dr["Price"];

                            if (dr["HasTv"] != DBNull.Value)
                                r.HasTv = (bool)dr["HasTv"];

                            if (dr["HasHairDryer"] != DBNull.Value)
                                r.HasHairDryer = (bool)dr["HasHairDryer"];

                            rooms.Add(r);
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            return rooms;
        }
        /// <summary>
        /// Used to count the number of room of an hotel
        /// used to adapt price
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountRoom(int id)
        {

            int cnt = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "select COUNT(*) from Room where IdHotel = @IdHotel";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", id);


                    cn.Open();

                    cnt = (Int32)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return cnt;
        }
        /// <summary>
        /// Count the number of room non-available during
        /// a specific amount of time
        /// used to adapt price
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public int CountRoomWithDate(int id, string dateStart, string dateEnd)
        {

            int cnt = new int();
            DateTime ds = new DateTime();
            DateTime de = new DateTime();

            if (dateStart != null)
                ds = DateTime.ParseExact(dateStart, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (dateEnd != null)
                de = DateTime.ParseExact(dateEnd, "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
            

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT COUNT(IdReservation) " +
                                    "FROM Booking " +
                                    "WHERE DateStart = @DateStart AND DateEnd = @dateEnd AND IdRoom IN (SELECT IdRoom FROM Room WHERE IdHotel = @IdHotel)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DateStart", ds);
                    cmd.Parameters.AddWithValue("@DateEnd", de);
                    cmd.Parameters.AddWithValue("@IdHotel", id);


                    cn.Open();

                    cnt = (Int32)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return cnt;
        }



    }


}
