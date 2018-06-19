using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

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

        public Team Team1 { get; set; }
        public Team Team2 { get; set; }

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
        public void viewNarration(string narration)
        {
            byte[] encodeBytes = Convert.FromBase64String(narration);
            string decode = System.Text.Encoding.UTF8.GetString(encodeBytes);
            this.Narration = loadNarration(decode);
        }

        public string loadNarration(string narration)
        {
            XDocument document = XDocument.Parse(narration);
            XElement root = document.Root;
            var xmlAttributeCollection = root.Elements().Attributes();
            string tableNarration = "";
            foreach (var ele in root.Elements())
            {
                if (!ele.HasElements)
                {
                    string elename = "";
                    tableNarration += "<tr>";

                    elename = ele.Name.ToString();

                    if (ele.HasAttributes)
                    {
                        IEnumerable<XAttribute> attribs = ele.Attributes();
                        foreach (XAttribute attrib in attribs)
                            elename += Environment.NewLine + attrib.Name.ToString() +
                              "=" + attrib.Value.ToString();
                    }
                    tableNarration += "<td>" + elename + "</td>";
                    tableNarration +=  "<td>" + ele.Value + "</td>";
                    tableNarration +=  "</tr>";
                }
                else
                {
                    string elename = "";
                    tableNarration += "<tr>";

                    elename = ele.Name.ToString();

                    if (ele.HasAttributes)
                    {
                        IEnumerable<XAttribute> attribs = ele.Attributes();
                        foreach (XAttribute attrib in attribs)
                            elename += Environment.NewLine + attrib.Name.ToString() + "=" + attrib.Value.ToString();
                    }

                    tableNarration += "<td>" + elename + "</td>";
                    tableNarration += "<td>" + loadNarration(ele.ToString()) + "</td>";
                    tableNarration += "</tr>";
                }
            }
            return tableNarration;

        }
    }
}