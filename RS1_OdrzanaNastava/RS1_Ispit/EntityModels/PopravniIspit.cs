using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class PopravniIspit
    {
        public int PopravniIspitId { get; set; }

        [ForeignKey(nameof(SkolaId))]
        public virtual Skola Skola { get; set; }
        public int SkolaId { get; set; }

        [ForeignKey(nameof(SkolskaGodinaId))]
        public virtual SkolskaGodina SkolskaGodina { get; set; }
        public int SkolskaGodinaId { get; set; }

        [ForeignKey(nameof(PredmetId))]
        public virtual Predmet Predmet { get; set; }
        public int PredmetId { get; set; }

        public DateTime Datum { get; set; }

        


    }
}