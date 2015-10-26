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
        public ActionResult AddTest(string number)
        {
            return RedirectToAction("AddTest", number);
        }

        public ActionResult AddQuestion()
        {
            QuizHandling myQuizHandling = new QuizHandling();


            return View("AddQuestion");
        }

        [HttpPost]
        public ActionResult AddQuestion(string number)
        {
            return RedirectToAction("AddQuestion", number);
        }

        public ActionResult DeleteTest()
        {
            QuizHandling myQuizHandling = new QuizHandling();


            return View("DeleteTest");
        }

        [HttpPost]
        public ActionResult DeleteTest(string number)
        {
            return RedirectToAction("DeleteTest", number);
        }

        public ActionResult EditTest()
        {
            QuizHandling myQuizHandling = new QuizHandling();


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