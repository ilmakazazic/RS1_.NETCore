using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PopravniIspitPrikaziVM
    {
        public int SkolskaGodinaId { get; set; }
        public int SkolaId { get; set; }

        public int PredmetId { get; set; }

        public class Row
        {
            public int PopravniIspitId { get; set; }

            public DateTime Datum { get; set; }
            public string Predmet { get; set; }

            public int BrojUcenikaNaPopravnomIspitu { get; set; }
            public int BrojUcenikaKojiSuPolozili { get; set; }

        }
        public List<Row> PopravniIspiti { get; set; }

    }
}
