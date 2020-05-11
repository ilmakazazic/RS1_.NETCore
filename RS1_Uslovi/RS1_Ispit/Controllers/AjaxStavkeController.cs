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
            AjaxStavkeIndexVM model = new AjaxStavkeIndexVM
            {
                Ucenici = _db.PopravniIspitUcenik.Where(x => x.PopravniIspitId == id).Select(x => new AjaxStavkeIndexVM.Row
                {
                    PopravniIspitUcenikId = x.PopravniIspitUcenikId,
                    Ucenik = x.OdjeljenjeStavka.Ucenik.ImePrezime,
                    Pristupio = x.Pristupio,
                    BrojUDnevniku = x.OdjeljenjeStavka.BrojUDnevniku,
                    RezultatPopravnog = x.Bodovi,
                    Odjeljenje = x.OdjeljenjeStavka.Odjeljenje.Oznaka
                }).ToList()

            };
            return PartialView(model);
          
        }

        public IActionResult UcenikJePrisutan(int id)
        {
            PopravniIspitUcenik pi = _db.PopravniIspitUcenik.Find(id);
            pi.Pristupio = true;
            _db.SaveChanges();

            return Redirect("/PopravniIspit/Uredi/" + pi.PopravniIspitId);
        }

        public IActionResult UcenikJeOdsutan(int id)
        {
            PopravniIspitUcenik pi = _db.PopravniIspitUcenik.Find(id);
            pi.Pristupio = false;
            _db.SaveChanges();

            return Redirect("/PopravniIspit/Uredi/" + pi.PopravniIspitId);
        }

        public IActionResult Uredi(int id) //popravniispitucenikid
        {
            PopravniIspitUcenik pi = _db.PopravniIspitUcenik.Where(x => x.PopravniIspitUcenikId == id).Include
                (x => x.OdjeljenjeStavka.Ucenik).FirstOrDefault();

            return PartialView(pi);
        }

        public IActionResult SnimiUredi(PopravniIspitUcenik model)
        {

            PopravniIspitUcenik pi = _db.PopravniIspitUcenik.Find(model.PopravniIspitUcenikId);
            pi.Bodovi = model.Bodovi;
            _db.SaveChanges();



            return Redirect("/AjaxStavke/Index/" + pi.PopravniIspitId);
        }

    }
}