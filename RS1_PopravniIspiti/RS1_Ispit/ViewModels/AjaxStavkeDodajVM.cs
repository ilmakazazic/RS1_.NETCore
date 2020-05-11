using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxStavkeDodajVM
    {
        public int PopravniIspitId { get; set; }

        public int Id { get; set; }

        public List<SelectListItem> Ucenici { get; set; }
    }
}
