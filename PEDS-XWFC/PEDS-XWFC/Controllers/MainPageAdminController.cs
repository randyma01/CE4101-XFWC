using PEDS_XWFC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Controllers
{
    public class MainPageAdminController : Controller
    {
        MainPageAdmin mainPage = new MainPageAdmin();
        // GET: MainPageAdmin
        public ActionResult MainPageAdmin()
        {
            return View();
        }


        public ActionResult NewTournament()
        {
            mainPage.loadData();
            return View("NewTournament", mainPage);
        }
    }
}