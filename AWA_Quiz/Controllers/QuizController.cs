using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWA_Quiz.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartNewTest()
        {
            string sessionState = "";
            return this.RedirectToAction("Index", "Quiz", new { error = sessionState });
        }


        public ActionResult ViewHistory()
        {
            string sessionState = "";
            return this.RedirectToAction("Index", "Quiz", new { error = sessionState });
        }
    }
}