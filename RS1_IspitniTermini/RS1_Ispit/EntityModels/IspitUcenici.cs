using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class IspitUcenici
    {

        public int Id { get; set; }

        public bool Pristupio { get; set; }
        public int? Ocjena { get; set; }
        
        public int SlusaPredmetId { get; set; }
        public SlusaPredmet SlusaPredmet { get; set; }

        public int IspitniTerminId { get; set; }
        public IspitniTermin IspitniTermin { get; set; }

    }
}
