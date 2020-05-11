using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class OdabirAngazovanVM
    {
        public List<RowPredmeta> sviPredmeti { get; set; }
        public class RowPredmeta
        {
            public string NazivPredmeta { get; set; }
            public int PredmetId { get; set; }
            public int AngazovanId { get; set; }

         
                public int AkademskaGodinaId { get; set; }
                public int NastavnikId { get; set; }
                public string AkademskaGodina { get; set; }
                public string Nastavnik { get; set; }
                public int BrojPredmeta { get; set; }
                public int BrojStudenata { get; set; }






        }

    }
}
