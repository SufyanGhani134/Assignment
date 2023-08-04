using Assignment.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class StudentsController : ApiController
    {
        public StudentsBL BusinessLayer = new StudentsBL();

        [HttpGet]
        [Route("GetAllStudents")]

        public List<Student> GetListofAllUsers()
        {
            try
            {
                List<Student> students = new List<Student>();
                students = BusinessLayer.GetAllStudents();
                return students;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetListOfAllStudents in controller due to "
                   + exception.Message, exception.InnerException);
            }

        }
        //[HttpGet]
        //[Route("GetStudentsByName")]

        //public List<Student> GetStudentsByName(string text)
        //{
        //    try
        //    {
        //        List<Student> students = new List<Student>();
        //        students = BusinessLayer.GetStudentsByName(text);
        //        return students;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception("An exception of type " + exception.GetType().ToString()
        //           + " is encountered in GetListOfAllStudents in controller due to "
        //           + exception.Message, exception.InnerException);
        //    }

        //}
    }
}
