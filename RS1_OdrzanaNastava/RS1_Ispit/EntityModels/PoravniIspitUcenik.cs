using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class PoravniIspitUcenik
    {
        public int PoravniIspitUcenikId { get; set; }

        [ForeignKey(nameof(PopravniIspitId))]
        public virtual PopravniIspit PopravniIspit { get; set; }
        public int PopravniIspitId { get; set; }

        [ForeignKey(nameof(OdjeljenjeStavkaId))]
        public virtual OdjeljenjeStavka OdjeljenjeStavka { get; set; }
        public int OdjeljenjeStavkaId { get; set; }

        public bool Pristupio { get; set; }
        public int Rezultat { get; set; }


    }
}
