using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class IspitniTermin
    {
        public int Id { get; set; }
        public DateTime DatumIspita { get; set; }

        public string Napomena { get; set; }

        public int AngazovanId { get; set; }
        public Angazovan Angazovan { get; set; }


    }
}
