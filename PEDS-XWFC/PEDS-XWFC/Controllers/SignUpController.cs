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

            newUser.createNewUser(firstName, lastName, userName, email, password, country, description, telephone, birthDate);

            return RedirectToAction("MainPage", "MainPage", new { idFanatic = this.newUser.IdFanatic });
        }


    }
}