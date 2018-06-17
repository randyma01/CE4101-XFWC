using PEDS_XWFC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Controllers
{
    public class LogInController : Controller
    {

        User user = new User();

        // GET: LogIn
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ButtonLogIn()
        {
            string userName = Request["userName"];
            string password = Request["password"];

            user.UserName = userName;
            user.Password = password;

            if (user.VerifyUser())
            {
                return RedirectToAction("MainPage", "MainPage");
            }
            else 
            {
                return View("LogIn");
            }

        }


    }
}
