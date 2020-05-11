using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxDodajVM
    {
        public int popravniID { get; set; }

        public int popravniUcenikID { get; set; }
        public string Ucenik { get; set; }
        public int Bodovi { get; set; }
    }
}
