using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    
    public class UserFanatic
    {
        public int IdUser{ get; set; }
        public int IdCountry { get; set; }
        public int Score{ get; set; }
        public String TelephoneNumber { get; set; }
        public String Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public String PersonalDescription { get; set; }


    }
}