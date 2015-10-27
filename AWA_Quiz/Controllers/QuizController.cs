using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BI;
using AWA_Quiz;

namespace AWA_Quiz.Controllers
{
    public class QuizController : Controller
    {

        QuizHandling myQuizHandling = new QuizHandling();


        // GET: Quiz
        //[Authorize]
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
            List<Models.QuizViewModel> quizTitles = new List<Models.QuizViewModel>();
            List<string> allTests = myQuizHandling.ReadAllTests();

            if (allTests == null)
            {
                return RedirectToAction("Index", "Quiz");
            }

            //foreach (var test in allTests)
            //{
            //    quizTitles.Add();
            //}
            return View(quizTitles);
        }



        //Find a way to distinguish between quiz or question
        [HttpPost]
        public ActionResult DeleteTest(string title)
        {
            
            myQuizHandling.DeleteQuiz(title);
                return View();
            
            
        }


        public ActionResult DeleteQuestion(string quizTitle)
        {
            List<Models.QuizViewModel> questionTitles = new List<Models.QuizViewModel>();
            List<string> allTests = myQuizHandling.ReadAllQuestions(quizTitle);

            if (allTests == null)
            {
                return RedirectToAction("Index", "Quiz");
            }

            //foreach (var test in allTests)
            //{
            //    quizTitles.Add();
            //}
            return View(questionTitles);
        }



        //Find a way to distinguish between quiz or question
        [HttpPost]
        public ActionResult DeleteQuestion(string questionTitle, string quizTitle)
        {
                myQuizHandling.DeleteQuestion(questionTitle);
            
            return View();
        }


        public ActionResult EditTest()
        {
            
            List<string> allTests = myQuizHandling.ReadAllTests();

            if (allTests == null)
            {
                return RedirectToAction("Index", "Quiz");
            }

            //foreach (var test in allTests)
            //{
            //    testList.tests.Add(test);
            //}
            return View(allTests);
            
        }



        [HttpPost]
        public ActionResult EditTest(string title, string description, int nrOfCorrectAnswers)
        {
            return RedirectToAction("EditTest");
        }


        public ActionResult StartTest()
        {
          
            List<string> allTests = myQuizHandling.ReadAllTests();
            if (allTests == null)
            {
                return RedirectToAction("Question", "Quiz");
            }

            //foreach (var test in allTests)
            //{
            //    testList.tests.Add(test);
            //}
            return View(allTests);
            
        }



        [HttpPost]
        public ActionResult StartTest(string quizTitle)
        {
            return RedirectToAction("StartTest");
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

        public ActionResult Question()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Question(string questionTitle, bool isCorrect)
        {
            return View();
        }
    }
}