using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using System.Linq.Expressions;

namespace DAL
{
    public class PictureDB : IPictureDB
    {
        private string connectionString = null;
        


        public PictureDB(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("MyConnection");
        }

        /// <summary>
        /// Use to get a specific picture of a specific room
        /// </summary>
        /// <param name="r"></param>
        /// <param name="idPicture"></param>
        /// <returns></returns>
        public Picture GetPicture(Room r, int idPicture)
        {

            if(r == null)
            {
                Console.WriteLine("room is empty");
                return null;
            }

            Picture p = null;
            
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "select * from Picture where IdRoom = @IdRoom and IdPicture = @IdPicture";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);
                    cmd.Parameters.AddWithValue("@IdPicture", idPicture);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr.Read())
                        {
                            p = new Picture();

                            p.IdPicture = (int)dr["IdPicture"];

                            if (dr["Url"] != DBNull.Value)
                                p.Url = (string)dr["Url"];

                            p.IdRoom = (int)dr["IdRoom"];

                        }
                    }
                }
            }catch(Exception e)
            {
                throw e;
            }  
            return p;
        }

        /// <summary>
        /// Will be used to get all the pictures of a specific room
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public List<Picture> GetPictures(Room r)
        {

            if(r == null)
            {
                Console.WriteLine("room empty");
                return null;
            }

            List<Picture> pictures = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Select * from Picture where IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (pictures == null)
                                pictures = new List<Picture>();

                            Picture p = new Picture();

                            p.IdPicture = (int)dr["IdPicture"];

                            p.IdRoom = (int)dr["IdRoom"];

                            if (dr["Url"] != DBNull.Value)
                                p.Url = (string)dr["Url"];

                            pictures.Add(p);
                        }
                    }

                }
            }catch(Exception e)
            {
                throw e;
            }
            return pictures;
        }

        /// <summary>
        /// Add a picture to a room
        /// </summary>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public Picture AddPicture(Picture p, Room r)
        {

            if(p == null || r == null)
            {
                Console.WriteLine("picture or room empty");
                return null;
            }

            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "insert into Picture (Url, IdRoom) values(@Url, @IdRoom)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Url", p.Url);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);

                    cn.Open();

                    p.IdPicture = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }catch(Exception e)
            {
                throw e;
            }
            return p;
        }

        /// <summary>
        /// Delete a specific picture
        /// </summary>
        /// <param name="r"></param>
        /// <param name="idPicture"></param>
        /// <returns></returns>
        public int DeleteSpecPicture(Room r, int idPicture)
        {

            if(r == null)
            {
                Console.WriteLine("room empty");
                return 0;
            }


            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "delete Picture where IdRoom = @IdRoom and IdPicture = @IdPicture";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);
                    cmd.Parameters.AddWithValue("@IdPicture", idPicture);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }catch(Exception e)
            {
                throw e;
            }
            return result;
        }


        /// <summary>
        /// Delete all the pictures of a room
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public int DeletePictures(Room r)
        {

            if(r == null)
            {
                Console.WriteLine("room empry");
                return 0;
            }

            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "delete Picture where IdRoom = @IdRoom";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);


                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }catch(Exception e)
            {
                throw e;
            }
            return result;
        }

        /// <summary>
        /// Update the url of a picture
        /// </summary>
        /// <param name="r"></param>
        /// <param name="idPicture"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public int UpdatePicture(Room r, int idPicture, string url)
        {

            if(r == null)
            {
                Console.WriteLine("room empry");
                return 0;
            }

            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "update Picture set Url = @Url where IdRoom = @IdRoom and IdPicture = @IdPicture";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Url", url);
                    cmd.Parameters.AddWithValue("@IdRoom", r.IdRoom);
                    cmd.Parameters.AddWithValue("@IdPicture", idPicture);

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
