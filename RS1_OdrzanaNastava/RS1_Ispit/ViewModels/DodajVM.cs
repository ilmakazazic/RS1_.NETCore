using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_asp.net_core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class DodajVM
    {
        public int PredmetID { get; set; }
        public string Predmet { get; set; }
        public int Razred { get; set; }
        public DateTime DatumIspita { get; set; }

        public int SkolaId { get; set; }
        public List<SelectListItem> Skole { get; set; }


        public int SkolskaGodinaId { get; set; }
        public List<SelectListItem> SkolskeGodine { get; set; }


    }
}
