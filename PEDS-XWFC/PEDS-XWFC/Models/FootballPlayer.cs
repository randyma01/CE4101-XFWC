using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    public class FootballPlayer
    {
        public int IdPlayer { get; set; }
        public string NamePlayer { get; set; }
        public int Passport { get; set; }
        public string Position { get; set; } //public enum Position {GK, DF, MF, CF}
        public string Country { get; set; }
        public string Club { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public int Status { get; set; } //Active: True or False
        public Statistic Statistics { get; set; }
    }
}