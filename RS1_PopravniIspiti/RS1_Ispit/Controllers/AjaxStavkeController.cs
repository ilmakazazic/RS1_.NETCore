using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class AjaxStavkeController : Controller
    {
        private MojContext _db;

        public AjaxStavkeController(MojContext db)
        {
            _db = db;
        }
        public IActionResult Index(int id)
        {
            PopravniIspit pi = _db.PopravniIspit.Find(id);
            AjaxStavkeIndexVM model = new AjaxStavkeIndexVM
            {
                PopravniIspitId = pi.PopravniIspitId,
                Ucenici = _db.PopravniIspitUcenik.Where(x => x.PopravniIspitId == id).Select(x => new AjaxStavkeIndexVM.Row
                {
                    UcenikId= x.PopravniIspitUcenikId,
                    Ucenik= x.OdjeljenjeStavka.Ucenik.ImePrezime,
                    PristupioIspitu= x.PristupioIspitu,
                    RezultatPopravnog= x.RezultatPopravnogIspita,
                    BrojUDnevniku= x.OdjeljenjeStavka.BrojUDnevniku,
                    Odjeljenje= x.OdjeljenjeStavka.Odjeljenje.Oznaka

                }).ToList()
            };
            return PartialView(model);
        }
        public IActionResult UcenikJePrisutan(int id)
        {
            PopravniIspitUcenik pu = _db.PopravniIspitUcenik.Find(id);
            pu.PristupioIspitu = true;
            _db.SaveChanges();
            return Redirect("/PopravniIspit/Uredi/" + pu.PopravniIspitId);
        }

        public IActionResult UcenikJeOdsutan(int id)
        {
            PopravniIspitUcenik pu = _db.PopravniIspitUcenik.Find(id);
            pu.PristupioIspitu = false;
            _db.SaveChanges();
            return Redirect("/PopravniIspit/Uredi/" + pu.PopravniIspitId);
        }

        public IActionResult Uredi(int id)
        {
            PopravniIspitUcenik it = _db.PopravniIspitUcenik.Where(x => x.PopravniIspitUcenikId == id).Include(x => x.OdjeljenjeStavka.Ucenik).FirstOrDefault();

            return PartialView(it);
        }

        public IActionResult Snimi(PopravniIspitUcenik it)
        {
            PopravniIspitUcenik novi = _db.PopravniIspitUcenik.Find(it.PopravniIspitUcenikId);

            novi.RezultatPopravnogIspita = it.RezultatPopravnogIspita;
            _db.SaveChanges();

            return Redirect("/PopravniIspit/Uredi/" + novi.PopravniIspitId);

        }

        public IActionResult Dodaj(int id)
        {
            PopravniIspit it = _db.PopravniIspit.Find(id);
            AjaxStavkeDodajVM model = new AjaxStavkeDodajVM
            {
                PopravniIspitId = it.PopravniIspitId,
                Ucenici = _db.Ucenik.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.ImePrezime

                }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult DodajSnimi(AjaxStavkeDodajVM model)
        {

            PopravniIspitUcenik novi = new PopravniIspitUcenik
            {
                PopravniIspitId = model.PopravniIspitId,
                OdjeljenjeStavkaId= model.Id,
                PristupioIspitu = true
            };

            _db.Add(novi);
            _db.SaveChanges();
            return Redirect("/AjaxStavke/Index/" + model.PopravniIspitId);
        }


    }
}