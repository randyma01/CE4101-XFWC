using PEDS_XWFC.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
    }
}