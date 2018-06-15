using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    public class ChampionMode
    {
        public int IdChampionMode { get; set; }
        public Tournament Tournament { get; set; }
        public NewUser FanUser { get; set; }



    }
}

