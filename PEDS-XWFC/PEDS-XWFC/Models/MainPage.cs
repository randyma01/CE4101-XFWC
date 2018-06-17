using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Models
{
    public class MainPage
    {

        public Tournament Tournament { get; set; }
        public List<SelectListItem> ListTournaments { get; set; }
        public int idUserFanatic { get; set; }
        public string Calendar { get; set; }
        public bool VisibilityVR { get; set; }
        public bool VisibilityVDT { get; set; }
        public bool VisibilitySIT { get; set; }

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

        public void loadCalendar(string idTournament, int idUser)
        {
            this.Tournament.NameTournament = this.ListTournaments[this.ListTournaments.FindIndex(x => x.Value.Equals(idTournament))].Text.ToString();
            Connection connection = new Connection();
            DataView dataView;
            string query = "SELECT Partido.IdPartido, GROUP_CONCAT(seleccion.NombreSeleccion SEPARATOR ' vs ' ) as Selecciones, Partido.Sede, Partido.Fecha, Narracion " +
                "FROM Partido " +
                "INNER JOIN seleccion_partido ON partido.IdPartido = seleccion_partido.IdPartido  " +
                "INNER JOIN seleccion ON seleccion_partido.IdSeleccion = seleccion.IdSeleccion  " +
                "WHERE IdTorneo = '" + idTournament +"' group by Partido.IdPartido";

            dataView = connection.getData(query);
            //IdPartido Selecciones Sede Fecha

            verifyStoT(idTournament, idUser);
            //Debug.WriteLine("Model MainPage - Torneo: " + idTournament  + " userFanatic: " + idUser);

            foreach (DataRowView datarow in dataView)
            {
                string selecciones = datarow["Selecciones"].ToString();
                string sede = datarow["Sede"].ToString();
                string fecha = datarow["Fecha"].ToString();
                string narracion = datarow["Narracion"].ToString();
                string idPartido = datarow["IdPartido"].ToString();
                this.Calendar += "<tr> " +
                             "<td>" + selecciones + "</td >" +
                             "<td>" + sede + "</td > " +
                             "<td>" + fecha + "</td > ";
                if (narracion.Equals("")) {
                    this.Calendar += "<td> <a href = '#' >  </a> </td > ";
                }
                else if (narracion.Equals("en vivo"))
                {
                    this.Calendar += "<td> <a href = '#' > En Vivo </a> </td > ";
                }
                else if (!narracion.Equals(""))
                {
                    this.Calendar += "<td> <a href = '#' > Ver narracion </a> </td > ";
                }

                this.Calendar += " </tr>";
            }
            
        }

        /*
         * Verify subscription to tournament
         * 
         */
        [NonAction]
        public void verifyStoT(string idTournament, int idUserFanatic)
        {
            Connection connection = new Connection();
            DataView dataView = connection.getData("SELECT IdFanatico FROM worldcupbd.fanatico_torneo WHERE idFanatico = " + idUserFanatic + " AND IdTorneo = " + idTournament);
            if (dataView.Count == 0)
            {
                this.VisibilitySIT = true;
                this.VisibilityVDT = false;
                this.VisibilityVR = false;
            }
            else
            {
                this.VisibilitySIT = false;
                this.VisibilityVDT = true;
                this.VisibilityVR = true;
            }
        }

    }
}