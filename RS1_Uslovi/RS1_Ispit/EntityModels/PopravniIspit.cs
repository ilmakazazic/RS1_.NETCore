using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class PopravniIspit
    {
        public int PopravniIspitId { get; set; }
        public DateTime DatumPopravnog { get; set; }
        public int OdjeljenjeId { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }
    }
}
