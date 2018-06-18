using PEDS_XWFC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Controllers
{
    public class LiveController : Controller
    {
        Game game = new Game();
        // GET: Live
        public ActionResult Live(string idGame)
        {
            Debug.WriteLine("Live - IdPartido: " + idGame);
            game.IdGame = Convert.ToInt32(idGame);
            game.loadViewTeams();
            return View(game);
        }
    }
}