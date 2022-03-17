using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MvcMovies.Models
{
    public class RegisterUsersDataAccessLayer
    {
        //  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MvcMoviesdbContext"].ToString());

        // String connection = ConfigurationManager.ConnectionStrings["MvcMoviesdbContext"].ToString();


        //   SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MvcMoviesdbContext"].ConnectionString );


        String con1 = GetConnectionString();
        public string RegisterUsers(RegisterUsersModel RegisterUsersModel)
        {

            SqlConnection connection = new SqlConnection(con1);
            try
            {


                SqlCommand cmd = new SqlCommand("spRegiterUsers", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", RegisterUsersModel.Name);
                cmd.Parameters.AddWithValue("@Surname", RegisterUsersModel.Surname);
                cmd.Parameters.AddWithValue("@Email", RegisterUsersModel.Email);
                cmd.Parameters.AddWithValue("@password", RegisterUsersModel.password);

                connection.Open();
                cmd.ExecuteNonQuery();

                //   Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                //   Console.WriteLine("State: {0}", connection.State);

                connection.Close();
                return ("Data save Successfully");

            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                return (ex.Message.ToString());

            }
        }


        public IEnumerable<RegisterUsersModel> ViewAllRegisterUsers()
        {
            List<RegisterUsersModel> listRegisterUsers = new List<RegisterUsersModel>();

            using (SqlConnection con = new SqlConnection(con1))
            {
                SqlCommand cmd = new SqlCommand("spViewAllRegisterUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    RegisterUsersModel xy = new RegisterUsersModel();

                    xy.Name = reader["Name"].ToString();
                    xy.Surname = reader["Surname"].ToString();
                    xy.Email = reader["Email"].ToString();
                    xy.password = reader["password"].ToString();

                    listRegisterUsers.Add(xy);

                }

                // Call Close when done reading.
                reader.Close();
                con.Close();

            }

            return listRegisterUsers;
        }





        public RegisterUsersModel GetRegisterUsers(int id)
        {
            RegisterUsersModel xy = new RegisterUsersModel();

            using (SqlConnection connection = new SqlConnection(con1))
            {
                String sqlquary = "Select *  from RegisterUsers where id= ";

                SqlCommand cmd = new SqlCommand(sqlquary, connection);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {


                    xy.id = Convert.ToInt32(reader["id"]);
                    xy.Name = reader["Name"].ToString();
                    xy.Surname = reader["Surname"].ToString();
                    xy.Email = reader["Email"].ToString();
                    xy.password = reader["password"].ToString();

                }
            }
            return xy;



            /*
                        SqlConnection connection = new SqlConnection(con1);

                        SqlCommand cmd = new SqlCommand("spDeleteRegisterUsers", connection);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id",RegisterUsersModel.id);
                        cmd.Parameters.AddWithValue("@Name", RegisterUsersModel.Name);
                        cmd.Parameters.AddWithValue("@Surname", RegisterUsersModel.Surname);
                        cmd.Parameters.AddWithValue("@Email", RegisterUsersModel.Email);
                        cmd.Parameters.AddWithValue("@password", RegisterUsersModel.password);


                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

              */

        }


        // to do ................
        public void UpdateRegisterUsers(RegisterUsersModel RegisterUsersModel)


        {
            using (SqlConnection connection = new SqlConnection(con1))
            {
                SqlCommand sqlcmd = new SqlCommand("spUpdateRegisterUsers", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;


            }
        }
           


        private static string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file, using the
            // System.Configuration.ConfigurationManager.ConnectionStrings property

            //return "Data Source=MSSQLLocalDB;Initial Catalog=MvcMoviesdb;"
            // + "Integrated Security=SSPI;";
            String con2 = ConfigurationManager.ConnectionStrings["MvcMovieDBContext"].ConnectionString;
            return con2;

        }
    }
}