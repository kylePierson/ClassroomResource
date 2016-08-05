using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassroomResource.Web.ViewModels;
using ClassroomResource.Data.Data_Access_Layer;
using ClassroomResource.Web.Web.ViewModels;
using ClassroomResource.Data.Models;

namespace ClassroomResource.Web.Controllers
{
    public class UsersController : ClassroomResourceController
    {
        private readonly IUserDAL userDal;

        public UsersController(IUserDAL userDal)
            : base(userDal)
        {
            this.userDal = userDal;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // ACCOUNT MANAGEMENT ACTIONS

        [HttpGet]
        public ActionResult ChangePassword(string username)
        {
            var model = new ChangePasswordViewModel();
            model.Username = username;
            return View("ChangePassword", model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ChangePassword", model);
            }

            userDal.ChangePassword(model.Username, model.NewPassword);

            return RedirectToAction("Index", "Quiz", new { username = base.CurrentUser });
        }

        [HttpGet]
        public ActionResult NewUser()
        {

            if (base.IsAuthenticated)
            {
                return RedirectToAction("Index", "Quiz", new { username = base.CurrentUser });
            }
            else
            {
                var model = new NewUserViewModel();
                return View("NewUser", model);
            }
        }

        [HttpPost]
        public ActionResult NewUser(NewUserViewModel model)
        {

            if (base.IsAuthenticated)
            {
                return RedirectToAction("Index", "Quiz", new { username = base.CurrentUser });
            }

            if (ModelState.IsValid)
            {
                var currentUser = userDal.GetUser(model.Username);

                if (currentUser != null)
                {
                    ViewBag.ErrorMessage = "This username is unavailable";
                    return View("NewUser", model);
                }

                var newUser = new User
                {
                    Username = model.Username,
                    Password = model.Password,
                };

                // Add the user to the database
                userDal.CreateUser(newUser);

                // Log the user in and redirect to the dashboard
                base.LogUserIn(model.Username);
                return RedirectToAction("Index", "Quiz", new { username = model.Username });
            }
            else
            {
                return View("NewUser", model);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (base.IsAuthenticated)
            {
                return RedirectToAction("Index", "Quiz", new { username = base.CurrentUser });
            }

            var model = new LoginViewModel();
            return View("Login", model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userDal.GetUser(model.Username, model.Password);

                // No user found with these credentials
                if (user == null)
                {
                    ViewBag.ErrorMessage = "The username or password provided is invalid";
                    return View("Login", model);
                }

                // Happy Path
                base.LogUserIn(user.Username);
                return RedirectToAction("Index", "Quiz", new { username = user.Username });
            }
            else
            {
                return View("Login", model);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            base.LogUserOut();

            return RedirectToAction("Index", "Home");
        }
    }
}