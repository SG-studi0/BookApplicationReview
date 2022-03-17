using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// need to add 

using System.Data.SqlClient;
using System.Configuration;
using System.Data;



namespace MvcMovies.Models
{
    public class BookDetailsDataAccessLayer
    {
        String con1 = GetConnectionString();

        public string CreateBookDetials(BookDetailsModel BookDetailsModel)
        {
            SqlConnection connection = new SqlConnection(con1);

            try
            {



                SqlCommand sqlcmd = new SqlCommand("spCreateBookDetails", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@BookName", BookDetailsModel.BookName);
                sqlcmd.Parameters.AddWithValue("@Author", BookDetailsModel.Author);
                sqlcmd.Parameters.AddWithValue("@Rating", BookDetailsModel.Rating);

                connection.Open();
                sqlcmd.ExecuteNonQuery();
                connection.Close();


                return ("Book detials saved");
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

        public IEnumerable<BookDetailsModel> ViewAllBookDetials()
        {
            List<BookDetailsModel> listBookDetials = new List<BookDetailsModel>();

            using (SqlConnection connection = new SqlConnection(con1))
            {
                SqlCommand sqlcmd = new SqlCommand("spViewAllBookDetials", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader sqldatareader = sqlcmd.ExecuteReader();

                while(sqldatareader.Read())
                {
                    BookDetailsModel xy = new BookDetailsModel();

                    xy.id = Convert.ToInt32(sqldatareader["id"]);
                    xy.BookName = sqldatareader["BookName"].ToString();
                    xy.Author = sqldatareader["Author"].ToString();
                    xy.Rating = sqldatareader["Rating"].ToString();

                    listBookDetials.Add(xy);

                }

                sqldatareader.Close();
                connection.Close();

                return listBookDetials;
            }
        }

        public void UpdateBookdetials(BookDetailsModel BookDetailsModel)

        {

            using (SqlConnection connection = new SqlConnection(con1))
            {
                SqlCommand sqlcmd = new SqlCommand("spUpdateBookDetials", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@bkid", BookDetailsModel.id);
                sqlcmd.Parameters.AddWithValue("@Bookname", BookDetailsModel.BookName);
                sqlcmd.Parameters.AddWithValue("@Author", BookDetailsModel.Author);
                sqlcmd.Parameters.AddWithValue("@Rating", BookDetailsModel.Rating);


                connection.Open();
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }



        }
        public BookDetailsModel GetBookDetials(int? id )
            {
            BookDetailsModel bookDetialsmodel = new BookDetailsModel();

            using (SqlConnection connection = new SqlConnection(con1))

            {
                

                SqlCommand sqlcmd = new SqlCommand("spGetBookDetials", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;

              
                // read the parameter id for values of id table
                    sqlcmd.Parameters.AddWithValue("@id", id);
                




                connection.Open();
                // sqlcmd.ExecuteNonQuery();

               

                SqlDataReader sqldatareader = sqlcmd.ExecuteReader();
            
              
                while (sqldatareader.Read())
                    {

                    // var paraid = new SqlParameter("@id", sqldatareader.GetInt32(0));
                    // sqlcmd.Parameters.Add(paraid);

                    //   sqlcmd.ExecuteNonQuery();
                   // SqlParameter p = new SqlParameter("@id", id);
                 //   sqlcmd.Parameters.Add(p)
                  //  sqlcmd.Parameters.AddWithValue("@id", bookDetialsmodel.id);
                    

                  

                         bookDetialsmodel.id = Convert.ToInt32(sqldatareader["id"]);
                       
                        bookDetialsmodel.BookName = sqldatareader["BookName"].ToString();
                        bookDetialsmodel.Author = sqldatareader["Author"].ToString();
                        bookDetialsmodel.Rating = sqldatareader["Rating"].ToString();

                    //  sqlcmd.Parameters.AddWithValue("@bkid", bookDetialsmodel.id);

                    //sqlcmd.ExecuteNonQuery();

                   


                }
              //  sqldatareader.Close();
               // connection.Close();

            }
            return bookDetialsmodel;
        }

        public void DeleteBookDetails(int? id)
        {

            using (SqlConnection connection = new SqlConnection(con1))
            {
                SqlCommand sqlcmd = new SqlCommand("spDeleteBookDetails", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@bkid", id);

                connection.Open();
                sqlcmd.ExecuteNonQuery();
                connection.Close();

            }
                

        }
       

        private static string GetConnectionString()
        {
            String con2 = ConfigurationManager.ConnectionStrings["MvcMovieDBContext"].ConnectionString;
            return con2;
        }

    }
}