using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdabirPredmetaVM
    {
        public List<Row> Predmeti { get; set; }
        public class Row
        {
            public int PredmetId { get; set; }
            public int Razred { get; set; }
            public string Naziv { get; set; }

        }

    }
}
