﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWA_Quiz.Controllers
{
    public class UserController : Controller
    {
        UserHandling myUserHandling = new UserHandling();

        // GET: User
        public ActionResult Index(string eMailAddress)
        {
            
            if (!string.IsNullOrEmpty(eMailAddress))
            {
                List<string> user = myUserHandling.ReadUser(eMailAddress);

                return View(user);
            }
            else
            {
                string status = "Invalid login attempt.";
                return RedirectToAction("Error", "Shared", new { error = status });
            }
            
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