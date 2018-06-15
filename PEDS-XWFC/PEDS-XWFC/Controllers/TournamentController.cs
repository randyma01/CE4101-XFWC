using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using PEDS_XWFC.Models;


namespace PEDS_XWFC.Controllers
{
    public class TournamentController : Controller
    {

        Tournament model = new Tournament();
        Connection connection = new Connection();
        List<SelectListItem> listTournaments = new List<SelectListItem>();


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShowTournaments()
        {
       
            DataView dataView;
            dataView = connection.getData("SELECT Torneo.Nombre, Patrocinador.NombrePatrocinador FROM Torneo INNER JOIN  Patrocinador ON Torneo.IdPatrocinador = Patrocinador.IdPatrocinador");

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["Nombre"].ToString() +" "+ datarow["NombrePatrocinador"].ToString() };
                listTournaments.Add(newItem);
            }

            return View(model);
        }
    }
}