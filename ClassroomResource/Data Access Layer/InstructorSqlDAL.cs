using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassroomResource.Models;

namespace ClassroomResource.Data_Access_Layer
{
    public class InstructorSqlDAL : IInstructorDAL
    {
        public bool ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool CreateInstructor(Instructor newInstructor)
        {
            throw new NotImplementedException();
        }

        public Instructor GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public Instructor GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}