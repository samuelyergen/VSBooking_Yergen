using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class HotelDB : IHotelDB
    {

        

        private IConfiguration Configuration { get; }

        public HotelDB(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        
       
        /// <summary>
        /// Return a list of all hotels
        /// </summary>
        /// <returns></returns>
        public List<Hotel> GetHotels()
        {
            List<Hotel> hotels = null;
            string connectionString = Configuration.GetConnectionString("MyConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Hotel";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (hotels == null)
                                hotels = new List<Hotel>();

                            Hotel hotel = new Hotel();

                            hotel.IdHotel = (int)dr["IdHotel"];

                            if (dr["Name"] != DBNull.Value)
                                hotel.Name = (string)dr["Name"];
                            if (dr["Description"] != DBNull.Value)
                                hotel.Description = (string)dr["Description"];
                            if (dr["Location"] != DBNull.Value)
                                hotel.Location = (string)dr["Location"];
                            if (dr["Category"] != DBNull.Value)
                                hotel.Category = (int)dr["Category"];
                            if (dr["HasWifi"] != DBNull.Value)
                                hotel.HasWifi = (bool)dr["HasWifi"];
                            if (dr["HasParking"] != DBNull.Value)
                                hotel.HasParking = (bool)dr["HasParking"];
                            if (dr["Phone"] != DBNull.Value)
                                hotel.Phone = (string)dr["Phone"];
                            if (dr["Website"] != DBNull.Value)
                                hotel.Website = (string)dr["Website"];


                            hotels.Add(hotel);


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return hotels;

        }
        /// <summary>
        /// return a specific hotel
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Hotel GetHotel(string name)
        {
            Hotel hotel = null;
            string connectionString = Configuration.GetConnectionString("MyConnection");


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Hotel where Name = @Name";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", name);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            hotel = new Hotel();
                            hotel.IdHotel = (int)dr["IdHotel"];

                            if (dr["Name"] != DBNull.Value)
                                hotel.Name = (string)dr["Name"];
                            if (dr["Description"] != DBNull.Value)
                                hotel.Description = (string)dr["Description"];
                            if (dr["Location"] != DBNull.Value)
                                hotel.Location = (string)dr["Location"];
                            if (dr["Category"] != DBNull.Value)
                                hotel.Category = (int)dr["Category"];
                            if (dr["HasWifi"] != DBNull.Value)
                                hotel.HasWifi = (bool)dr["HasWifi"];
                            if (dr["HasParking"] != DBNull.Value)
                                hotel.HasParking = (bool)dr["HasParking"];
                            if (dr["Phone"] != DBNull.Value)
                                hotel.Phone = (string)dr["Phone"];
                            if (dr["Website"] != DBNull.Value)
                                hotel.Website = (string)dr["Website"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;

            }

            return hotel;
        }

        public List<Hotel> GetHotelsByLocation(string location, string searchDateStartString, string searchDateEndString)
        {
            List<Hotel> hotels = null;
            string connectionString = Configuration.GetConnectionString("MyConnection");

            if (string.IsNullOrWhiteSpace(location))
                return null;


            DateTime startDate;
            DateTime endDate;
            DateTime.TryParse(searchDateStartString, out startDate);
            DateTime.TryParse(searchDateEndString, out endDate);

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select h.*, r.*, b.* from Booking as b " +
                        "INNER JOIN Room as r ON r.IdRoom = b.IdRoom " +
                        "INNER JOIN Hotel as h ON r.IdHotel = h.IdHotel " +
                        "WHERE 1=1 ";

                    if (startDate != DateTime.MinValue)
                        query += $"AND b.DateStart >=  Convert(datetime, '{startDate.ToString("YYYY-MM-dd")}') ";

                    if (endDate != DateTime.MinValue)
                        query += $"AND b.EndStart >=  Convert(datetime, '{endDate.ToString("YYYY-MM-dd")}') ";

                    query += $"WHERE h.Location = @Location";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Location", location);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (hotels == null)
                                hotels = new List<Hotel>();

                            Hotel hotel = new Hotel();

                            hotel.IdHotel = (int)dr["IdHotel"];

                            if (dr["Name"] != DBNull.Value)
                                hotel.Name = (string)dr["Name"];
                            if (dr["Description"] != DBNull.Value)
                                hotel.Description = (string)dr["Description"];
                            if (dr["Location"] != DBNull.Value)
                                hotel.Location = (string)dr["Location"];
                            if (dr["Category"] != DBNull.Value)
                                hotel.Category = (int)dr["Category"];
                            if (dr["HasWifi"] != DBNull.Value)
                                hotel.HasWifi = (bool)dr["HasWifi"];
                            if (dr["HasParking"] != DBNull.Value)
                                hotel.HasParking = (bool)dr["HasParking"];
                            if (dr["Phone"] != DBNull.Value)
                                hotel.Phone = (string)dr["Phone"];
                            if (dr["Website"] != DBNull.Value)
                                hotel.Website = (string)dr["Website"];


                            hotels.Add(hotel);


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return hotels;

        }
        /// <summary>
        /// Get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hotel GetHotelById(int id)
        {
            Hotel hotel = null;
            string connectionString = Configuration.GetConnectionString("MyConnection");


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Hotel where IdHotel = @IdHotel";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdHotel", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            hotel = new Hotel();
                            hotel.IdHotel = (int)dr["IdHotel"];

                            if (dr["Name"] != DBNull.Value)
                                hotel.Name = (string)dr["Name"];
                            if (dr["Description"] != DBNull.Value)
                                hotel.Description = (string)dr["Description"];
                            if (dr["Location"] != DBNull.Value)
                                hotel.Location = (string)dr["Location"];
                            if (dr["Category"] != DBNull.Value)
                                hotel.Category = (int)dr["Category"];
                            if (dr["HasWifi"] != DBNull.Value)
                                hotel.HasWifi = (bool)dr["HasWifi"];
                            if (dr["HasParking"] != DBNull.Value)
                                hotel.HasParking = (bool)dr["HasParking"];
                            if (dr["Phone"] != DBNull.Value)
                                hotel.Phone = (string)dr["Phone"];
                            if (dr["Website"] != DBNull.Value)
                                hotel.Website = (string)dr["Website"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return hotel;
        }
        /// <summary>
        /// Can retrun a list of available hotels
        /// during a specific period of time
        /// </summary>
        /// <param name="location"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public List<Hotel> GetHotelsWithDate(string location, DateTime dateStart, DateTime dateEnd)
        {
            List<Hotel> hotels = null;
            string connectionString = Configuration.GetConnectionString("MyConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                   

                    string query = "Select * from Hotel " +
                        "WHERE Location = @Location " +
                        "AND IdHotel NOT IN (Select h.IdHotel from Booking as b " +
                        "INNER JOIN Room as r ON r.IdRoom = b.IdRoom " +
                        "INNER JOIN Hotel as h ON r.IdHotel = h.IdHotel " +
                        "AND b.DateStart >= @DateStart " +
                        "AND b.DateEnd <= @DateEnd)";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@DateStart", dateStart);
                    cmd.Parameters.AddWithValue("@DateEnd", dateEnd);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (hotels == null)
                                hotels = new List<Hotel>();

                            Hotel hotel = new Hotel();

                            hotel.IdHotel = (int)dr["IdHotel"];

                            if (dr["Name"] != DBNull.Value)
                                hotel.Name = (string)dr["Name"];
                            if (dr["Description"] != DBNull.Value)
                                hotel.Description = (string)dr["Description"];
                            if (dr["Location"] != DBNull.Value)
                                hotel.Location = (string)dr["Location"];
                            if (dr["Category"] != DBNull.Value)
                                hotel.Category = (int)dr["Category"];
                            if (dr["HasWifi"] != DBNull.Value)
                                hotel.HasWifi = (bool)dr["HasWifi"];
                            if (dr["HasParking"] != DBNull.Value)
                                hotel.HasParking = (bool)dr["HasParking"];
                            if (dr["Phone"] != DBNull.Value)
                                hotel.Phone = (string)dr["Phone"];
                            if (dr["Website"] != DBNull.Value)
                                hotel.Website = (string)dr["Website"];


                            hotels.Add(hotel);


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return hotels;

        }
        /// <summary>
        /// Method used for the advanced search of hotels
        /// take all filters in parameters
        /// </summary>
        /// <param name="location"></param>
        /// <param name="category"></param>
        /// <param name="hasParking"></param>
        /// <param name="hasWifi"></param>
        /// <returns></returns>
        public List<Hotel> GetHotelsAdvancedSearch(string location, string category, string hasParking, string hasWifi)
        {
            List<Hotel> hotels = null;
            string connectionString = Configuration.GetConnectionString("MyConnection");

            int cat = 0;
            bool hp = false;
            bool hw = false;

            if (category != null)
                cat = int.Parse(category);

            if (hasParking != null)
                hp = bool.Parse(hasParking);

            if (hasWifi != null)
                hw = bool.Parse(hasWifi);
       

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "select * from Hotel ";

                    if (location != null)
                        query += "WHERE Location = @Location ";
                    else if (location == null && category != null)
                        query += "WHERE Category = @Category ";
                    else if (location == null && category == null && hasParking != null)
                        query += "WHERE HasParking = @HasParking ";
                    else if (location == null && category == null && hasParking == null && hasWifi != null)
                        query += "WHERE HasWifi = @HasWifi ";

                    if (category != null)
                        query += "AND Category = @Category ";
                    if (hasParking != null)
                        query += "AND HasParking = @HasParking ";
                    if (hasWifi != null)
                        query += "AND HasWifi = @HasWifi";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    if(location != null)
                        cmd.Parameters.AddWithValue("@Location", location);
                    if(category != null)
                        cmd.Parameters.AddWithValue("@Category", cat);
                    if(hasParking != null)
                        cmd.Parameters.AddWithValue("@HasParking", hp);
                    if(hasWifi != null)
                        cmd.Parameters.AddWithValue("@HasWifi", hw);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (hotels == null)
                                hotels = new List<Hotel>();

                            Hotel hotel = new Hotel();

                            hotel.IdHotel = (int)dr["IdHotel"];

                            if (dr["Name"] != DBNull.Value)
                                hotel.Name = (string)dr["Name"];
                            if (dr["Description"] != DBNull.Value)
                                hotel.Description = (string)dr["Description"];
                            if (dr["Location"] != DBNull.Value)
                                hotel.Location = (string)dr["Location"];
                            if (dr["Category"] != DBNull.Value)
                                hotel.Category = (int)dr["Category"];
                            if (dr["HasWifi"] != DBNull.Value)
                                hotel.HasWifi = (bool)dr["HasWifi"];
                            if (dr["HasParking"] != DBNull.Value)
                                hotel.HasParking = (bool)dr["HasParking"];
                            if (dr["Phone"] != DBNull.Value)
                                hotel.Phone = (string)dr["Phone"];
                            if (dr["Website"] != DBNull.Value)
                                hotel.Website = (string)dr["Website"];


                            hotels.Add(hotel);


                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;

            }
            return hotels;

        }

    }
}
