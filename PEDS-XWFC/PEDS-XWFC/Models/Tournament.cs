using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PEDS_XWFC.Models
{
    public class Tournament
    {
        public Sponsor MainSponsor { get; set; }
        public int IdTournament{ get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
        public string Country { get; set; }
        public List<Power> ListPowers { get; set; }
        public List<Game> ListGames { get; set; }
        public List<Teams> ListTeams { get; set; }
]

    }
}

