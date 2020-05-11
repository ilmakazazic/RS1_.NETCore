using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class DodajIspitVM
    {
        public int AngazovanId { get; set; }
        public int IspitniTerminId { get; set; }
        public string Predmet { get; set; }
        public string AkademskaGodina { get; set; }
        public string Nastavnik { get; set; }

        public DateTime DatumIspita { get; set; }
        public string Napomena { get; set; }

    }
}
