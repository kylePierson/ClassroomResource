using ClassroomResource.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassroomResource.Web.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index(string username)
        {
            //maybe show list of quizes under a user
            QuizListVM quizListModel = new QuizListVM();
                //get list of quizes for current instructor
            return View("Index", quizListModel);
        }

        public ActionResult CreateQuiz(string username)
        {

            return View("CreateQuiz");
        }

        [HttpPost]
        public ActionResult CreateQuiz(CreateQuizVM quizModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateQuiz", quizModel);
            }

            //Add values from quizModel to viewQuizModel
            ViewQuizVM viewQuizModel = new ViewQuizVM();
            return RedirectToAction("Index", "Questions",viewQuizModel);
        }       
    }
}