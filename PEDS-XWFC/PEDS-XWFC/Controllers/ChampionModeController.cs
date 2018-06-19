using PEDS_XWFC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Controllers
{
    public class ChampionModeController : Controller
    {

        ChampionMode ChampionModeM = new ChampionMode();

        // GET: ChampionMode
        public ActionResult ChampionMode()
        {
            string idTournament = Request["Tournament.NameTournament"];
            Debug.WriteLine(idTournament);
            ChampionModeM.LoadGames("1");
            return View(ChampionModeM);
        }
    }
}