using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class IspitniVM
    {
        public int AngazovanId { get; set; }

        public string Predmet { get; set; }
        public string AkademskaGodina { get; set; }
        public string Nastavnik { get; set; }
        
        public List<Row> Ispiti { get; set; }
        public class Row
        {
            public int IspitniTerminId { get; set; }
            public DateTime DatumIspita { get; set; }
            public int Nepolozeni { get; set; }
            public int Prijavljeni { get; set; }
            public bool EvidentiranRezultat { get; set; }

        }

    }
}
