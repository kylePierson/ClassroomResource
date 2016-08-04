using ClassroomResource.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassroomResource.Controllers
{
    public class QuestionsController : Controller
    {
        // GET: Questions
        public ActionResult Index(ViewQuizVM viewQuizModel)
        {
            //show list of questions for a certain quiz

            return View("Index", viewQuizModel);
        }

        public ActionResult AddQuestion(ViewQuizVM viewQuizModel)
        {
            //Take data from viewQuizVM and put it in the following VM
            AddQuestionVM addQuestionModel = new AddQuestionVM();
            return View("AddQuestion", addQuestionModel);
        }

        public ActionResult CreateTrueFalse(AddQuestionVM addQuestionModel)
        {
            //take data out of parameter passed in from AddQuestion view and assign to the following VM
            CreateTrueFalseVM trueFalseModel = new CreateTrueFalseVM();
            return View("CreateTrueFalse", trueFalseModel);
        }

        [HttpPost]
        public ActionResult CreateTrueFalse(CreateTrueFalseVM trueFalseModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateTrueFalse", trueFalseModel);
            }

            //Add values from trueFalseModel to viewQuizModel
            ViewQuizVM viewQuizModel = new ViewQuizVM();
            return RedirectToAction("ViewQuiz", viewQuizModel);
        }

        public ActionResult CreateMultipleChoice(AddQuestionVM addQuestionModel)
        {
            //take data out of parameter passed in from AddQuestion view and assign to the following VM
            CreateMultipleChoiceVM multipleChoiceModel = new CreateMultipleChoiceVM();
            return View("CreateMultipleChoice", multipleChoiceModel);
        }

        [HttpPost]
        public ActionResult CreateMultipleChoice(CreateMultipleChoiceVM multipleChoiceModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateMultipleChoice", multipleChoiceModel);
            }

            //Add values from multipleChoiceModel to viewQuizModel
            ViewQuizVM viewQuizModel = new ViewQuizVM();
            return RedirectToAction("ViewQuiz", viewQuizModel);
        }

        public ActionResult CreateShortAnswer(AddQuestionVM addQuestionModel)
        {
            //take data out of parameter passed in from AddQuestion view and assign to the following VM
            CreateShortAnswerVM shortAnswerModel = new CreateShortAnswerVM();
            return View("CreateShortAnswer", shortAnswerModel);
        }

        [HttpPost]
        public ActionResult CreateShortAnswer(CreateShortAnswerVM shortAnswerModel)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateShortAnswer", shortAnswerModel);
            }

            //Add values from shortAnswerModel to viewQuizModel
            ViewQuizVM viewQuizModel = new ViewQuizVM();
            return RedirectToAction("Index", viewQuizModel);
        }
    }
}