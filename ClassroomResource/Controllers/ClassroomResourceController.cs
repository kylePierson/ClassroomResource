using ClassroomResource.Data.Data_Access_Layer;
using ClassroomResource.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassroomResource.Data.Models;

namespace ClassroomResource.Web.Controllers
{
    public class ClassroomResourceController: Controller
    {
        private const string UsernameKey = "ClassroomResource_UserName";
        private readonly IUserDAL userDal;

        public ClassroomResourceController(IUserDAL userDal)
        {
            this.userDal = userDal;
        }


        /// <summary>
        /// Gets the value from the Session
        /// </summary>
        public string CurrentUser
        {
            get
            {
                string username = string.Empty;

                //Check to see if user cookie exists, if not create it
                if (Session[UsernameKey] != null)
                {
                    username = (string)Session[UsernameKey];
                }

                return username;
            }
        }

        /// <summary>
        /// Returns bool if user has authenticated in
        /// </summary>        
        public bool IsAuthenticated
        {
            get
            {
                return Session[UsernameKey] != null;
            }
        }

        /// <summary>
        /// "Logs" the current user in
        /// </summary>
        public void LogUserIn(string username)
        {

            Session[UsernameKey] = username;
        }

        /// <summary>
        /// "Logs out" a user by removing the cookie.
        /// </summary>
        public void LogUserOut()
        {
            Session.Abandon();
        }


        [ChildActionOnly]
        public ActionResult GetAuthenticatedUser()
        {
            User model = null;

            if (IsAuthenticated)
            {
                model = userDal.GetUser(CurrentUser);
            }

            return View("_AuthenticationBar", model);
        }
    }
}