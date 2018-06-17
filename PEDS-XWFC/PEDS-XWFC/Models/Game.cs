using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    public class Game
    {
        public int IdGame { get; set; }
        public string Date { get; set; }
        public string Score { get; set; }
        public string Narration { get; set; }
        public string Result { get; set; }
        public string Place { get; set; }

        public Teams Team1 { get; set; }
        public Teams Team2 { get; set; }

        public string viewTeam1 { get; set; }
        public string viewTeam2 { get; set; }

        public void loadViewTeams()
        {
            string query = "SELECT  Futbolista.NombreFutbolista FROM seleccion_partido " +
                "INNER JOIN seleccion ON seleccion_partido.IdSeleccion = seleccion.IdSeleccion " +
                "INNER JOIN futbolista_seleccion ON seleccion.IdSeleccion = futbolista_seleccion.IdSeleccion " +
                "INNER JOIN futbolista ON futbolista_seleccion.IdFutbolista = futbolista.IdFutbolista " +
                "WHERE IdPartido = " + this.IdGame;
            Connection connection = new Connection();
            DataView dataView;
            dataView = connection.getData(query);

            //team1
            for (int i = 0; i < 11; i++)
            {
                DataRowView datarow = dataView[i];
                string name = datarow["NombreFutbolista"].ToString();
                this.viewTeam1 += "<tr> " +
                             "<td>" + name + "</td >" + 
                              " </tr>";
            }
            //team 2
            for (int i = 11; i < 22; i++)
            {
                DataRowView datarow = dataView[i];
                string name = datarow["NombreFutbolista"].ToString();
                this.viewTeam2 += "<tr> " +
                             "<td>" + name + "</td >" +
                              " </tr>";
            }
        }
    }
}