using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class PopravniIspitUcenik
    {
        public int PopravniIspitUcenikId { get; set; }
        public bool Pristupio { get; set; }
        public int? Bodovi { get; set; }
        public int PopravniIspitId { get; set; }
        public PopravniIspit PopravniIspit { get; set; }
        public int OdjeljenjeStavkaId { get; set; }
        public OdjeljenjeStavka OdjeljenjeStavka { get; set; }
    }
}
