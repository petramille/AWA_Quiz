using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWA_Quiz.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddUser()
        {

            return View("AddUser");
        }

        [HttpPost]
        public ActionResult AddUser(string number)
        {
            return RedirectToAction("AddUser", number);
        }

    }
}