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