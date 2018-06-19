using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Models
{
    public class NewUser
    {

        [Required]
        public User User{ get; set; }
        public UserFanatic UserFanatic { get; set; }
        public int IdFanatic { get; set; }
        public string Country { get; set; }
        public List<SelectListItem> ListCountries { get; set; }

        public void loadCountries()
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
        }

        public void createNewUser(string firstName, string lastName, string userName, string email, string password,
                                string country, string description, string telephone, string birthDate)
        {
            Connection connection = new Connection();
            List<string> valuesUser = new List<string>();
            valuesUser.Add(firstName);
            valuesUser.Add(lastName);
            valuesUser.Add(email);
            valuesUser.Add(userName);
            valuesUser.Add(password);
            connection.insertData("Usuario", valuesUser);
            DataView dataView = connection.getData("SELECT IdUsuario FROM Usuario WHERE Username = '" + userName+ "'");
            string idUsuario = dataView[0].Row["IdUsuario"].ToString();
            List<string> valuesFanatic = new List<string>();
           
            valuesFanatic.Add(telephone);
            valuesFanatic.Add("0");
            valuesFanatic.Add(country);
            valuesFanatic.Add(idUsuario);
            valuesFanatic.Add(description);
            valuesFanatic.Add("");
            connection.insertData("Fanatico", valuesFanatic);
            dataView = connection.getData("SELECT IdFanatico FROM Fanatico WHERE IdUsuario = '" + idUsuario + "'");
            this.IdFanatic = Convert.ToInt32(dataView[0].Row["IdFanatico"].ToString());
        }
    }
}