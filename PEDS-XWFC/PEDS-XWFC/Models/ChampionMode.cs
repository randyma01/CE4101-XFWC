using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
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



        public void LoadGames(string idTournament)
        {
            Connection connection = new Connection();
            DataView dataView;

            string query = "SELECT  partido.IdPartido, seleccion.NombreSeleccion AS Selecciones FROM" + 
                "partido INNER JOIN seleccion_partido ON partido.IdPartido = seleccion_partido.IdPartido" +
                "INNER JOIN seleccion ON seleccion_partido.IdSeleccion = seleccion.IdSeleccion WHERE" + idTournament;

            dataView = connection.getData(query);

            foreach (DataRowView datarow in dataView)
            {
                string selecciones = datarow["Selecciones"].ToString();
                string idPartido = datarow["IdPartido"].ToString();
            }

        }

    }
}

