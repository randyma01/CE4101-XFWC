using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Models
{
    public class MainPage
    {

        public Tournament Tournament { get; set; }
        public List<SelectListItem> ListTournaments { get; set; }
        public string Calendar { get; set; }
       

        public void loadTournaments()
        {
            this.Tournament = new Tournament();
            this.Tournament.NameTournament = "";
            Connection connection = new Connection();
            DataView dataView;
            dataView = connection.getData("SELECT NombreTorneo, IdTorneo FROM Torneo");
            this.ListTournaments = new List<SelectListItem>();

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["NombreTorneo"].ToString(), Value = datarow["IdTorneo"].ToString() };
                this.ListTournaments.Add(newItem);
            }
        }

        public void loadCalendar(string idTournament)
        {
            this.Tournament.NameTournament = this.ListTournaments[this.ListTournaments.FindIndex(x => x.Value.Equals(idTournament))].Text.ToString();
            Connection connection = new Connection();
            DataView dataView;
            string query = "SELECT Partido.IdPartido, GROUP_CONCAT(seleccion.NombreSeleccion SEPARATOR ' vs ' ) as Selecciones, Partido.Sede, Partido.Fecha " +
                "FROM Partido  INNER JOIN seleccion_partido ON partido.IdPartido = seleccion_partido.IdPartido  " +
                "INNER JOIN seleccion ON seleccion_partido.IdSeleccion = seleccion.IdSeleccion  " +
                "WHERE IdTorneo = '" + idTournament +"' group by Partido.IdPartido";

            dataView = connection.getData(query);
            //IdPartido Selecciones Sede Fecha

            foreach (DataRowView datarow in dataView)
            {
                string selecciones = datarow["Selecciones"].ToString();
                string sede = datarow["Sede"].ToString();
                string fecha = datarow["Fecha"].ToString();
                this.Calendar += "<tr> " +
                             "<td>" + selecciones + "</td >" +
                             "<td>" + sede + "</td > " +
                             "<td>" + fecha + "</td > " +
                             "<td> <a href = 'http://localhost:53780/LogIn/LogIn' > Ver narracion </a> </td > " +
                             " </tr>";
            }
        }

    }
}