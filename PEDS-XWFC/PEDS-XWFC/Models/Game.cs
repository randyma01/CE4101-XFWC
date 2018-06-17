using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    public class Game
    {
        public int IdGame { get; set; }
        public string Date { get; set; }
        public string Score { get; set; }
        public string Narration { get; set; }
        public string Result { get; set; }
        public string Place { get; set; }
    }
}