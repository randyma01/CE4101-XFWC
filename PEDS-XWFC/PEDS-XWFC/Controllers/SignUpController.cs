using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PEDS_XWFC.Models;
using System.Diagnostics;

namespace PEDS_XWFC.Controllers
{
    public class SignUpController : Controller
    {

        NewUser newUser = new NewUser();
        // GET: SignUp
        public ActionResult SignUp()
        {
            newUser.loadCountries();
            return View(newUser);
        }

        [HttpPost]
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

        
        [HttpPost]
        public ActionResult CreateAccount()
        {
            string firstName = Request["User.FirstName"];
            string lastName = Request["User.LastName"];
            string userName = Request["User.UserName"];
            string email = Request["User.Email"];
            string password = Request["User.Password"];
            string country = Request["Country"];  //get: IdCountry
            string description = Request["UserFanatic.PersonalDescription"];
            string telephone = Request["UserFanatic.TelephoneNumber"];
            string birthDate = Request["UserFanatic.BirthDate"];  //get: yyyy-mm-dd


            return RedirectToAction("MainPage", "MainPage");
        }


    }
}