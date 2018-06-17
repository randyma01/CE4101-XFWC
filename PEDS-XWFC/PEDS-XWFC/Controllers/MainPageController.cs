using PEDS_XWFC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PEDS_XWFC.Controllers
{
    public class MainPageController : Controller
    {
        MainPage main = new MainPage();
        
        // GET: MainPage
        public ActionResult MainPage(string idFanatic)
        {
   
            main.idUserFanatic = Convert.ToInt32(idFanatic);
            main.loadTournaments();
            return View(main);
        }

        [HttpPost]
        public ActionResult Calendar(int idFanatic)
        {
            main.loadTournaments();
            string idTournament = Request["Tournament.NameTournament"];
            main.idUserFanatic = idFanatic;
            main.loadCalendar(idTournament, main.idUserFanatic);

            return View("MainPage", main);
        }
    }
}