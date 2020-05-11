using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxOcjena
    {
        public int IspitniTerminId { get; set; }
        public int IspitUcenikId { get; set; }
        public string ImeStudenta { get; set; }
        public int? Ocjena { get; set; }
    }
}
