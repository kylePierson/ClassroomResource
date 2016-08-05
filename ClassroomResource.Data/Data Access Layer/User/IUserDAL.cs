using ClassroomResource.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomResource.Data.Data_Access_Layer
{
    public interface IUserDAL
    {
        User GetUser(string username, string password);
        User GetUser(string username);

        bool CreateUser(User newUser);
        bool ChangePassword(string username, string newPassword);
    }
}
