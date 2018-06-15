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

        Connection connection = new Connection();
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

            User user = new User();
            user.UserName = userName;
            user.Password = password;

            if (user.VerifyUser())
            {
                return RedirectToAction("MainPage", "MainPage");
            }
            else if (userName.Length != 0)
            {
                return View("LogIn");
            }

        }


    }
}