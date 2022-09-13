using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class ReservationDB : IReservationDB
    {
        //One connection for every request
        private string connectionString = null;
       // private IConfiguration Configuration { get; }

        public ReservationDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MyConnection");
        }

        /**
         * Get all reservations
         * **/
        public List<Reservation> GetReservations()
        {
            List<Reservation> results = null;
           // string connectionString = Configuration.GetConnectionString("MyConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "select * from Reservation";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Reservation>();

                            Reservation res = new Reservation();

                            res.IdReservation = (int)dr["IdReservation"];

                            if (dr["Firstname"] != null)
                                res.Firstname = (string)dr["Firstname"];

                            if (dr["Lastname"] != null)
                                res.Lastname = (string)dr["Lastname"];

                            results.Add(res);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return results;
        }

        /**
         * To get a reservation by number of reservation(idReservation), firstname and lastname
         * **/
        public Reservation GetReservation(int idReservation)
        {
            Reservation res = null;
           // string connectionString = Configuration.GetConnectionString("MyConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "select * from Reservation where IdReservation = @IdReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdReservation", idReservation);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            res = new Reservation();

                            res.IdReservation = (int)dr["IdReservation"];

                            if (dr["Firstname"] != null)
                                res.Firstname = (string)dr["Firstname"];

                            if (dr["Lastname"] != null)
                                res.Lastname = (string)dr["Lastname"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return res;
        }

        /// <summary>
        /// Add a reservation
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        public int AddReservation(Reservation re)
        {

            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "insert into Reservation(Firstname, Lastname) values(@Firstname, @Lastname); SELECT SCOPE_IDENTITY()" ;
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", re.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", re.Lastname);

                    cn.Open();

                    re.IdReservation = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return re.IdReservation;
        }


        /// <summary>
        /// Delete a reservation
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        public int DeleteReservation(Reservation re)
        {          

            int result = 0;
           
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "delete Reservation where IdReservation = @IdReservation AND Firstname = @Firstname AND Lastname = @Lastname";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdReservation", re.IdReservation);
                    cmd.Parameters.AddWithValue("@Firstname", re.Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", re.Lastname);

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
        /// Will be used to update the firstname and/or name
        /// </summary>
        /// <param name="re"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public int UpdateReservation(Reservation re, string firstname, string lastname)
        {

            if (re == null)
            {
                Console.WriteLine("reservation empty");
                return 0;
            }

            int result = 0;
          
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "update Reservation set Firstname = @Firstname, Lastname = @Lastname where IdReservation = @IdReservation";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Firstname", firstname);
                    cmd.Parameters.AddWithValue("@Lastname", lastname);
                    cmd.Parameters.AddWithValue("@IdReservation", re.IdReservation);

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

    }
}
