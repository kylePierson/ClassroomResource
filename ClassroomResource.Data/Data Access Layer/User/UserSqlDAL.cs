using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassroomResource.Data.Models;

namespace ClassroomResource.Data.Data_Access_Layer
{
    public class UserSqlDAL : IUserDAL
    {
        public bool ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool CreateUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}