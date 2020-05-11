using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxPrikazUceniciVM
    {
        public List<Row> ucenici { get; set; }
        public class Row
        {
            public int PopravniIspitUcenikID { get; set; }
            public string Ucenik { get; set; }
            public string Odjeljenje { get; set; }
            public int BrojUdnevniku { get; set; }
            public int RezultatMaturskog { get; set; }
            public bool Pristupio { get; set; }

        }
    }
}
