using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Models
{
    public class NewUser
    {
        [Required]
        public User GetUser { get; set; }
        
        public UserFanatic GetUserFanatic { get; set; }
        public string Country { get; set; }
        public List<SelectListItem> ListCountries { get; set; }
    }
}