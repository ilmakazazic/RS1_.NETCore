using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxUcenici
    {
        public List<Row> ucenici { get; set; }
        public int IspitniTerminId { get; set; }
        public class Row
        {
            public int IspitUceniciId { get; set; }
            public string ImeUcenika { get; set; }
            public bool Pristupio { get; set; }
            public int? Ocjena { get; set; }

        }
    }
}
