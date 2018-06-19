using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Models
{
    public class MainPageAdmin
    {
        public Tournament Tournament { get; set; }
        public List<SelectListItem> ListCountries { get; set; }
        public List<SelectListItem> ListSoponsors { get; set; }
        public List<SelectListItem> ListTeams { get; set; }
        public List<int> ListTeamsForTournament { get; set; }

        public void loadData()
        {
            Connection connection = new Connection();
            DataView dataView;
            dataView = connection.getData("SELECT * FROM Pais");
            this.ListCountries = new List<SelectListItem>();

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["NombrePais"].ToString(), Value = datarow["IdPais"].ToString() };
                this.ListCountries.Add(newItem);
            }

            dataView = connection.getData("SELECT * FROM Patrocinador");
            this.ListSoponsors = new List<SelectListItem>();

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["NombrePatrocinador"].ToString(), Value = datarow["IdPatrocinador"].ToString() };
                this.ListSoponsors.Add(newItem);
            }

            dataView = connection.getData("SELECT * FROM Seleccion");
            this.ListTeams = new List<SelectListItem>();

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["NombreSeleccion"].ToString(), Value = datarow["IdSeleccion"].ToString() };
                this.ListTeams.Add(newItem);
            }
        }
    }
}