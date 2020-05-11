using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class SlusaPredmet
    {
        public int Id { get; set; }
        public DateTime? DatumOcjene { get; set; }
        public int? Ocjena { get; set; }

        public string Napomena { get; set; }

        [ForeignKey(nameof(AngazovanId))]
        public virtual Angazovan Angazovan { get; set; }
        public int AngazovanId { get; set; }

        [ForeignKey(nameof(UpisGodineId))]
        public virtual UpisGodine UpisGodine { get; set; }
        public int UpisGodineId { get; set; }
    }
}
