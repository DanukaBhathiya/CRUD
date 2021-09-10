using LMSWebAPI.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSWebAPI.DataAccess
{
    public class BooksManage
    {
        public static List<Books> GetAllBooks()
        {
            try
            {
                List<Books> booksList = new List<Books>();
                SqlConnection con = new SqlConnection();
                con = DBConnection.DBConn();
                con.Open();

                string sql = "SELECT * FROM  BOOKS";
                SqlCommand command = new SqlCommand(sql, con);
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Books item = new Books
                        {
                            Id = reader.GetInt32(0),
                            BookCode = reader.GetString(1),
                            BookName = reader.GetString(2),
                            BookCount = reader.GetInt32(3)
                        };
                        booksList.Add(item);
                    }
                }
                return booksList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool InsertBooks(Books Books)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con = DBConnection.DBConn();
                con.Open();

                string sql = "INSERT INTO BOOKS(BOOK_CODE,BOOK_NAME,BOOK_COUNT) VALUES(@BOOK_CODE,@BOOK_NAME,@BOOK_COUNT)";

                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@BOOK_CODE", Books.BookCode);
                command.Parameters.AddWithValue("@BOOK_NAME", Books.BookName);
                command.Parameters.AddWithValue("@BOOK_COUNT", Books.BookCount);
                command.ExecuteNonQuery();
                command.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static bool UpdateBooks(int id, Books book) 
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con = DBConnection.DBConn();
                con.Open();

                string sql = "UPDATE BOOKS SET BOOK_CODE=@BOOK_CODE,BOOK_NAME=@BOOK_NAME,BOOK_COUNT=@BOOK_COUNT " + "WHERE ID=@ID";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@BOOK_CODE", book.BookCode);
                command.Parameters.AddWithValue("@BOOK_NAME", book.BookName);
                command.Parameters.AddWithValue("@BOOK_COUNT", book.BookCount);
                command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static bool DeleteBooka(int id)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con = DBConnection.DBConn();
                con.Open();
                string sql = "DELETE FROM BOOKS WHERE ID=@ID";
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@ID", id);
                command.ExecuteNonQuery();
                command.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
