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
            mainPage.loadTournaments();
            return View(mainPage);
        }

        [HttpPost]
        public ActionResult ViewCalendar()
        {
            mainPage.loadTournaments();
            string idTournament = Request["Tournament.NameTournament"];
            
            mainPage.loadCalendar(idTournament);

            return View("MainPageAdmin", mainPage);
        }

        public ActionResult NewTournament()
        {
            mainPage.loadData();
            return View("NewTournament", mainPage);
        }

        [HttpPost]
        public ActionResult AddTeam()
        {
            string idTeam = Request["Team"];
            mainPage.addNewTeamToTournament(idTeam);
            return View("NewTournament", mainPage);
        }
    }
}