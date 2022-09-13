using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class BookingDB : IBookingDB
    {

        private string connectionString = null;

       
        
        
        
        public BookingDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MyConnection");
        }

        
         ///return a list because a reservation can have multiple room         
        public List<Booking> GetBooking(int idReservation)
        {
            List<Booking> bookings = null;

            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "select * from Booking where IdReservation = @IdReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdReservation", idReservation);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            if (bookings == null)
                                bookings = new List<Booking>();

                            Booking b = new Booking();

                            b.IdReservation = (int)dr["IdReservation"];
                            b.IdRoom = (int)dr["IdRoom"];

                            if (dr["DateStart"] != DBNull.Value)
                            {
                                b.DateStart = (DateTime)dr["DateStart"];
                            }
                            if (dr["DateEnd"] != DBNull.Value)
                            {
                                b.DateEnd = (DateTime)dr["DateEnd"];
                            }

                            bookings.Add(b);
                        }
                    }


                }
            }catch(Exception e)
            {
                throw e;
            }
            return bookings;
        }
        
          ///Add an entry in booking table
          ///Will be use in a loop for multiple room reservation         
        public int AddBooking(int idReservation, int idRoom, DateTime dateStart, DateTime dateEnd)
        {

  
            int result = 0;
            
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "insert into Booking (IdRoom, IdReservation, DateStart, DateEnd) values(@IdRoom, @IdReservation, @DateStart, @DateEnd)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", idRoom);
                    cmd.Parameters.AddWithValue("@IdReservation", idReservation);
                    cmd.Parameters.AddWithValue("@DateStart", dateStart);
                    cmd.Parameters.AddWithValue("@DateEnd", dateEnd);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }catch(Exception e)
            {
                throw e;
            }
            return result;
        }

        
         ///Delete all bookings related to the reservation        
        public int DeleteBooking(Reservation re)
        {

            if(re == null)
            {
                Console.WriteLine("reservation is empty");
                return 0;
            }

            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "delete Booking where IdReservation = @IdReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdReservation", re.IdReservation);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }catch(Exception e)
            {
                throw e;
            }
            return result;
        }

        
         ///Will be used to update a room and/or the dates        
        public int UpdateRoomBooking(Reservation re, Room r, Room rr, DateTime dateStart, DateTime dateEnd)
        {
            if(re == null || r == null)
            {
                Console.WriteLine("reservation or room is empty");
                return 0;
            }

            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "update Booking set DateStart = @DateStart, DateEnd = @DateEnd, IdRoom = @IdRoom1 where IdReservation = @IdReservation and IdRoom = @IdRoom2";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DateStart", dateStart);
                    cmd.Parameters.AddWithValue("@DateEnd", dateEnd);
                    cmd.Parameters.AddWithValue("@IdRoom1", r.IdRoom);
                    cmd.Parameters.AddWithValue("@IdRoom2", rr.IdRoom);
                    cmd.Parameters.AddWithValue("@IdReservation", re.IdReservation);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }catch(Exception e)
            {
                throw e;
            }
            return result;
        }

        
         ///Will be used to change the dates        
        public int UpdateDateBooking(Reservation re, Room r, DateTime dateStart, DateTime dateEnd)
        {

            if(re == null || r == null)
            {
                Console.WriteLine("reservation or room empty");
                return 0;
            }

            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "update Booking set DateStart = @DateStart, DateEnd = @DateEnd where IdReservation = @IdReservation and IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@DateStart", dateStart);
                    cmd.Parameters.AddWithValue("@DateEnd", dateEnd);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);

                    cmd.Parameters.AddWithValue("@IdReservation", re.IdReservation);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();

                }
            }catch(Exception e)
            {
                throw e;
            }
            return result;
        }




    }
}
