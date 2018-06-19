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
    public class MainPageAdmin
    {
        public Tournament Tournament { get; set; }
        public List<SelectListItem> ListTournaments { get; set; }
        public string Calendar { get; set; }
        public string Team { get; set; }
        public List<SelectListItem> ListCountries { get; set; }
        public List<SelectListItem> ListCountriesToTournament { get; set; }
        public List<SelectListItem> ListSoponsors { get; set; }
        public List<SelectListItem> ListTeams { get; set; }
        public string viewListTeams { get; set; }
        public List<int> ListTeamsForTournament { get; set; }


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

        public void loadData()
        {
            this.ListTeams = new List<SelectListItem>();
            Connection connection = new Connection();
            DataView dataView;
            dataView = connection.getData("SELECT * FROM Pais");
            this.ListCountries = new List<SelectListItem>();
            this.ListCountriesToTournament = new List<SelectListItem>();

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["NombrePais"].ToString(), Value = datarow["IdPais"].ToString() };
                this.ListCountries.Add(newItem);
                this.ListCountriesToTournament.Add(newItem);

            }

            dataView = connection.getData("SELECT * FROM Patrocinador");
            this.ListSoponsors = new List<SelectListItem>();

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["NombrePatrocinador"].ToString(), Value = datarow["IdPatrocinador"].ToString() };
                this.ListSoponsors.Add(newItem);
            }
            

        }

        public void addNewTeamToTournament(string index)
        {
            
            var newItem = new SelectListItem { Text = this.ListCountriesToTournament[Convert.ToInt32(index)].Text,  Value = this.ListCountriesToTournament[Convert.ToInt32(index)].Value };
            this.viewListTeams += "<tr><td><input type='checkbox' name='" 
                + this.ListCountriesToTournament[Convert.ToInt32(index)].Text.ToString() + "' />" 
                + this.ListCountriesToTournament[Convert.ToInt32(index)].ToString() + "</td></tr>";
            this.ListTeams.Add(newItem);
            
        }

        public void loadCalendar(string idTournament)
        {
            Debug.WriteLine(idTournament);
            this.Tournament.NameTournament = this.ListTournaments[this.ListTournaments.FindIndex(x => x.Value.Equals(idTournament))].Text.ToString();
            Connection connection = new Connection();
            DataView dataView;
            string query = "SELECT Partido.IdPartido, GROUP_CONCAT(seleccion.NombreSeleccion SEPARATOR ' vs ' ) as Selecciones, Partido.Sede, Partido.Fecha, Narracion " +
                "FROM Partido " +
                "INNER JOIN seleccion_partido ON partido.IdPartido = seleccion_partido.IdPartido  " +
                "INNER JOIN seleccion ON seleccion_partido.IdSeleccion = seleccion.IdSeleccion  " +
                "WHERE IdTorneo = '" + idTournament + "' group by Partido.IdPartido";

            dataView = connection.getData(query);
            
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

                if (narracion.Equals(""))
                {
                    this.Calendar += "<td> <a href = '#' > Crear Narracion </a> </td > ";
                }
                else if (!narracion.Equals(""))
                {
                    narracion = "<?xml version='1.0' encoding='UTF-8'?>" + narracion;
                    byte[] encode = System.Text.Encoding.UTF8.GetBytes(narracion);
                    string narracion1 = Convert.ToBase64String(encode);
                    this.Calendar += "<td> <a href= " + "http://localhost:53780/Live/Live?idGame=" + idPartido +
                        "&narration=" + narracion1 + "> Ver Narracion </a> </td>";
                }
                this.Calendar += " </tr>";
            }
        }
    }
}