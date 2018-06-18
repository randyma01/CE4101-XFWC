using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using PEDS_XWFC.Controllers;

namespace PEDS_XWFC.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string IdUserFanatic { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email    { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        

        /*
         * 
         */
        public bool VerifyUser()
        {
            Connection connection = new Connection();
            DataView dataView;
            dataView = connection.getData("SELECT IdUsuario, NombreUsuario, ApellidoUsuario, Correo FROM Usuario WHERE Username= '" + this.UserName + "' AND Clave= '" + this.Password + "' ");

            if (dataView.Count == 0)
            {
                return false;
            }
            else
            {
                DataRowView datarow = dataView[0];
                this.IdUser = Convert.ToInt32(datarow["IdUsuario"]);
                return true;
            }
        }

        public bool VerifyAdmin()
        {
            Connection connection = new Connection();
            DataView dataView;
            dataView = connection.getData("SELECT IdAdmin FROM administrador WHERE IdUsuario = " + this.IdUser);

            if (dataView.Count == 0) //is fanatic
            {
                this.IdUserFanatic = connection.getData("SELECT IdFanatico FROM Fanatico WHERE IdUsuario = " + this.IdUser)[0]["IdFanatico"].ToString();
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}