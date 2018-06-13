using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Controllers
{
    public class LogInController : Controller
    {

        Connection connection = new Connection();
        // GET: LogIn
        public ActionResult LogIn()
        {    
            return View();
        }

        public ActionResult ButtonLogIn()
        {
            DataView dataView;
            dataView = connection.getData("SELECT * FROM Pais");
            //model.ListCountries = new List<SelectListItem>();

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["NombrePais"].ToString(), Value = datarow["IdPais"].ToString() };
                //model.ListCountries.Add(newItem);
            }
            return View();

        }


    }
}