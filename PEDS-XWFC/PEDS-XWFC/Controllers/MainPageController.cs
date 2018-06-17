using PEDS_XWFC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Controllers
{
    public class MainPageController : Controller
    {
        MainPage main = new MainPage();
        UserFanatic userFanatic = new UserFanatic();
        
        // GET: MainPage
        public ActionResult MainPage()
        {
            
            main.loadTournaments();
            return View(main);
        }

        [HttpPost]
        public ActionResult Calendar()
        {
            main.loadTournaments();
            string idTournament = Request["Tournament.NameTournament"];
            main.loadCalendar(idTournament);
            return View("MainPage", main);
        }
    }
}