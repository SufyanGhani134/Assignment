using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static Assignment.DataLayer.StudentsDL;
using Assignment.Models;
using Assignment.DataLayer;

namespace Assignment.BusinessLayer
{
    public class StudentsBL
    {
        public StudentsDL studentDL = new StudentsDL();
        public List<Student> GetAllStudents()
        {
            try
            {
                DataTable table = new DataTable();
                List<Student> students = new List<Student>();
                table = studentDL.GetAllStudents();
                if (table != null && table.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in table.Rows)
                    {
                        Student student = new Student();
                        student.ID = Convert.ToInt32(dataRow["ID"]);
                        student.FirstName = dataRow["FirstName"].ToString();
                        student.LastName = dataRow["LastName"].ToString();
                        student.Age = Convert.ToInt32(dataRow["Age"]);
                        student.Course = dataRow["Course"].ToString();
                        students.Add(student);
                    }
                }
                return students;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetAllStudents in BL due to "
                   + exception.Message, exception.InnerException);
            }
        }
        //public List<Student> GetStudentsByName(string text)
        //{
        //    try
        //    {
        //        DataTable table = new DataTable();
        //        List<Student> students = new List<Student>();
        //        table = studentDL.GetStudentsByName(text);
        //        if (table != null && table.Rows.Count > 0)
        //        {
        //            foreach (DataRow dataRow in table.Rows)
        //            {
        //                Student student = new Student();
        //                student.FirstName = dataRow["FirstName"].ToString();
        //                student.LastName = dataRow["LastName"].ToString();
        //            }
        //        }
        //        return students;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("An exception of type " + exception.GetType().ToString()
        //           + " is encountered in GetAllStudents in BL due to "
        //           + exception.Message, exception.InnerException);
        //    }
        //}
    }
}