using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Assignment.Models;

namespace Assignment.DataLayer
{
    public class StudentsDL
    {
        string _connectionString = "";
        public StudentsDL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["BlogDBCN"].ConnectionString;
        }

        public DataTable GetAllStudents()
        {
            try
            {
                DataTable studentsTable = new DataTable();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("fetchData", con);
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    dataAdapter.Fill(studentsTable);
                    con.Close();
                }
                return studentsTable;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllStudents in DL due to "
                   + exception.Message, exception.InnerException);
            }

        }
        //public DataTable GetStudentsByName(string text)
        //{
        //    try
        //    {
        //        DataTable studentsTable = new DataTable();
        //        using (SqlConnection con = new SqlConnection(_connectionString))
        //        {
        //            SqlCommand command = new SqlCommand("fetchDataByName", con);
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add(new SqlParameter("@text", SqlDbType.VarChar, 50));
        //            command.Parameters["@text"].Value = text;

        //            con.Open();
        //            SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //            dataAdapter.SelectCommand = command;
        //            dataAdapter.Fill(studentsTable);
        //            con.Close();
        //        }
        //        return studentsTable;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("An exception of type " + exception.GetType().ToString()
        //           + " is encountered in GetAllStudents in DL due to "
        //           + exception.Message, exception.InnerException);
        //    }

        //}

    }
}