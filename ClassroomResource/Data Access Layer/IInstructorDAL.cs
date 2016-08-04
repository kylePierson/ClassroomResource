using ClassroomResource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassroomResource.Data_Access_Layer
{
    interface IInstructorDAL
    {
        Instructor GetUser(string username, string password);
        Instructor GetUser(string username);

        bool CreateInstructor(Instructor newInstructor);
        bool ChangePassword(string username, string newPassword);
    }
}
