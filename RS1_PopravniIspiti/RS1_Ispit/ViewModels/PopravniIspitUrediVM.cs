using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PopravniIspitUrediVM
    {
        public int PopravniIspitId { get; set; }
        public int Komisija1Id { get; set; }
        public string Komisija1 { get; set; }

        public int Komisija2Id { get; set; }
        public string Komisija2 { get; set; }
        public int Komisija3Id { get; set; }
        public string Komisija3 { get; set; }

        public DateTime Datum { get; set; }

        public int PredmetId { get; set; }
        public string Predmet { get; set; }

        public int SkolskaGodinaId { get; set; }

        public string SkolskaGodina { get; set; }

        public int SkolaId { get; set; }

        public string Skola { get; set; }
    }
}
