using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    
    public class UserFanatic
    {
        public int IdUser { get; set; }
        public int IdCountry { get; set; }
        public int Score { get; set; }
        public string Photo { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        [Required]
        public string PersonalDescription { get; set; }
    }
}