using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PEDS_XWFC.Models
{
    public class Prediction
    {
        public int IdPrediction { get; set; }
        public string Result { get; set; }
        public Game Game { get; set; }
        public int IdFanaticUser { get; set; }
    }
}