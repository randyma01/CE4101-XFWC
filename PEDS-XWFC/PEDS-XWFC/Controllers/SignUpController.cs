using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using PEDS_XWFC.Models;

namespace PEDS_XWFC.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult SignUp()
        {

            MySqlConnection mySqlConnection = new MySqlConnection("server=localhost; user id=root; database=worldcupbd; password=alonso; SslMode = none");

            mySqlConnection.Open();


            MySqlCommand sqlCommand = new MySqlCommand("SELECT * FROM Pais", mySqlConnection);
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);

            DataView dataView;
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            dataView = dataSet.Tables[0].DefaultView;

            var model = new NewUser();
            model.ListCountries = new List<SelectListItem>();

            foreach (DataRowView datarow in dataView)
            {
                var newItem = new SelectListItem { Text = datarow["NombrePais"].ToString(), Value = datarow["IdPais"].ToString() };
                model.ListCountries.Add(newItem);
            }

            sqlCommand.Dispose();
            mySqlConnection.Close();
            return View(model);
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image 
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            
            return RedirectToAction("SignUp", "SignUp");
        }
    }
}