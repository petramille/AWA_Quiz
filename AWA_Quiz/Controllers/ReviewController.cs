using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWA_Quiz.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartReview()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StartReview(string review)
        {
            return View();
        }

    }
}
