using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxStavkeIndexVM
    {
        public int Id { get; set; }
        public class Row
        {
            public int PopravniIspitUcenikId { get; set; }
            public string Ucenik { get; set; }
            public string Odjeljenje { get; set; }
            public int BrojUDnevniku { get; set; }
            public bool Pristupio { get; set; }
            public int? RezultatPopravnog { get; set; }

        }
        public List<Row> Ucenici { get; set; }

    }
}
