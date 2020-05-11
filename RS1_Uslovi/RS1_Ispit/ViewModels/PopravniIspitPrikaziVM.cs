using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PopravniIspitPrikaziVM
    {
        public int Id { get; set; }
        public class Row
        {
            public int Id { get; set; }
            public DateTime Datum { get; set; }
            public string Predmet { get; set; }
            public int BrojUcenikaNaPopravnom { get; set; }
            public int BrojUcenikaKojiSuPolozili { get; set; }

        }
        public List<Row> PopravniIspiti { get; set; }
    }

}
