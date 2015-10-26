using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BI;

namespace AWA_Quiz.Controllers
{
    public class QuizController : Controller
    {

        QuizHandling myQuizHandling = new QuizHandling();


        // GET: Quiz
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AddTest()
        {

            return View("AddTest");
        }

        [HttpPost]
        public ActionResult AddTest(string title, string description, string category)
        {
            if (!string.IsNullOrEmpty(title))
            {
                int quizId = myQuizHandling.CreateQuiz(title, description, category);
                Session["quizId"] = quizId;
                return View();
            }
            else
            {

                return RedirectToAction("AddTest");
            }
        }

        public ActionResult AddQuestion()
        {
            return View("AddQuestion");
        }



        [HttpPost]
        public ActionResult AddQuestion(string title, string description, int nrOfCorrectAnswers)
        {
            if (!string.IsNullOrEmpty(title))
            {
                int quizId = (int)Session["quizId"];
                int questionId = myQuizHandling.CreateQuestion(quizId, title, description, nrOfCorrectAnswers);
                return View();
            }
            else
            return RedirectToAction("AddQuestion");
        }

        public ActionResult DeleteTest()
        {
           


            return View("DeleteTest");
        }

        [HttpPost]
        public ActionResult DeleteTest(string number)
        {
            return RedirectToAction("DeleteTest", number);
        }



        public ActionResult EditTest()
        {
            


            return View("EditTest");
        }



        [HttpPost]
        public ActionResult EditTest(string number)
        {
            return RedirectToAction("EditTest", number);
        }

        public ActionResult StartTest()
        {

            return View("StartTest");
        }



        [HttpPost]
        public ActionResult StartTest(string number)
        {
            return RedirectToAction("StartTest", number);
        }



        public ActionResult ViewResult()
        {


            return View("ViewResults");
        }


        [HttpPost]
        public ActionResult ViewResult(string number)
        {
            return RedirectToAction("ViewResults", number);
        }
    }
}