using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class OdrzaniCasDetalji
    {
        public int Id { get; set; }
        public bool Prisutan { get; set; }
        public int BodoviNaCasu { get; set; }
        [ForeignKey(nameof(OdrzaniCasoviId))]
        public OdrzaniCas OdrzaniCasovi { get; set; }
        public int OdrzaniCasoviId { get; set; }
        [ForeignKey(nameof(SlusaPredmeteId))]
        public SlusaPredmet SlusaPredmete { get; set; }
        public int SlusaPredmeteId { get; set; }


    }
}