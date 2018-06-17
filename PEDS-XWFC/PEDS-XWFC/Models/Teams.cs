using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    public class Teams
    {
        public int IdTeam { get; set; }
        public string NameTeam { get; set; }
        public List<FootballPlayer>  Listlayers { get; set; }
    }
}