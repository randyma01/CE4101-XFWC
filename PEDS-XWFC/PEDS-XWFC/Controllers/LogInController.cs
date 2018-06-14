using System;
using System.Collections.Generic;
using System.Data;
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

       
        public ActionResult ButtonLogIn()
        {
         
            return View("Index", "MainPage");

        }


    }
}