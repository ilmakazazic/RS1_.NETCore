using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class PopravniIspitDodajVM
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int PredmetId { get; set; }
        public List<SelectListItem> Predmet { get; set; }

        public string Skola { get; set; }

        public string SkolskaGodina { get; set; }

        public string Odjeljenje { get; set; }


    }
}
