using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Controllers
{
    public class MainPageAdminController : Controller
    {
        // GET: MainPageAdmin
        public ActionResult MainPageAdmin()
        {
            return View();
        }


        public ActionResult NewTournament()
        {
            return View("NewTournament");
        }
    }
}