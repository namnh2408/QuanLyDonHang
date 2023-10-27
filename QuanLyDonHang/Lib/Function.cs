using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyDonHang.Lib
{
    public static class Function
    {
        private static string connectionString = "Data Source=localhost;Initial Catalog=QuanLyDonHang;Integrated Security=True";

        public static DataTable ExcuteQuery(string query, ref string error)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(data);
                }
                catch (SqlException e)
                {
                    error = e.Message;
                    data = null;
                }
                finally
                {
                    connection.Close();
                }
            }
            return data;
        }
        public static int ExcuteNonQuery(string query, ref string error)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    data = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    error = e.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
            return data;
        }
        public static object ExcuteScalar(string query)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    data = command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    string s = e.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
            return data;
        }

        public static SqlDataReader ExcuteReader(string strSql, CommandType ct)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand comm = connection.CreateCommand();
            if (connection.State == ConnectionState.Open)
                connection.Close();
            connection.Open();
            comm.CommandText = strSql;
            comm.CommandType = ct;
            connection.Close();
            return comm.ExecuteReader();
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", string.Empty, RegexOptions.Compiled);
        }
    }
}
