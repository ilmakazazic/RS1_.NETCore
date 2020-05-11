using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PrikazPopravnihVM
    {
        public List<Row> Popravni { get; set; }
        public int PredmetID { get; set; }

        public class Row
        {
            public int PopravniIspitId { get; set; }

            public string Skola { get; set; }
            public string SkolskaGodina { get; set; }
            public DateTime DatumPopravnog { get; set; }
            public int BrojUcenika { get; set; }
            public int BrojPolozenih { get; set; }

        }
    }
}
