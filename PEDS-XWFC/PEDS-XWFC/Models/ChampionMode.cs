using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    public class ChampionMode
    {
        public int IdChampionMode { get; set; }
        public Tournament Tournament { get; set; }
        public int IdUserFanatic { get; set; }
        public Prediction Prediction { get; set; }

        public List<String> Teams { get; set; }

        public string ViewTeam1 { get; set; }
        public string ViewTeam2 { get; set; }
        public string ViewGame { get; set; }


        public void LoadGames(string idTournament)
        {
            Connection connection = new Connection();
            DataView dataView;

            string query =
                "SELECT partido.IdPartido, GROUP_CONCAT(seleccion.NombreSeleccion SEPARATOR ',' ) AS Selecciones " +
                "FROM Partido INNER JOIN seleccion_partido ON partido.IdPartido = seleccion_partido.IdPartido " +
                "INNER JOIN seleccion ON seleccion_partido.IdSeleccion = seleccion.IdSeleccion " +
                "WHERE idTorneo = " + idTournament + " GROUP BY Partido.IdPartido";

            dataView = connection.getData(query);

            Teams = new List<string>();

            foreach (DataRowView datarow in dataView)
            {
                this.Teams.Add(datarow["Selecciones"].ToString());
                string idPartido = datarow["IdPartido"].ToString();
            }
            this.ViewGame = "";
            for (int i = 0; i < Teams.Count; i++)
            {
                string[] TeamsList = Teams[i].Split(',');

                Debug.WriteLine(TeamsList[0]);
                Debug.WriteLine(TeamsList[1]);

                this.ViewGame += "<ul class='matchup'> " +
                    "<li> <input style='width: 25px' size='1' type='number'/> " +
                    "<tr> " +
                    " <td>" + TeamsList[0] + "</td>" +
                    "</tr> " +
                    "</li> " +
                    "<li> <input style='width: 25px' size='1' type='number'/> " +
                    "<tr> " +
                    " <td>" + TeamsList[1] + "</td>" +
                    "</tr> " +
                    "</li> " +
                    "</ul>" +
                    "</div>";
            }
        }
    }
}

