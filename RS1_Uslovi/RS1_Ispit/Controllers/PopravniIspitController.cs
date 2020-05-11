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
    public class PopravniIspitController : Controller
    {
        private MojContext _db;
        public PopravniIspitController(MojContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            PopravniIspitIndexVM model = new PopravniIspitIndexVM
            {
               Odjeljenje= _db.Odjeljenje.Select(x=>new PopravniIspitIndexVM.Row
               {
                   Id=x.Id,
                   Skola= x.Skola.Naziv,
                   SkolskaGodina= x.SkolskaGodina.Naziv,
                   Odjeljenje= x.Oznaka,

               }).ToList()
            };
            return View(model);
        }
        public IActionResult Prikazi(int id)
        {
            var odjeljenje = _db.Odjeljenje.Find(id);
            PopravniIspitPrikaziVM model = new PopravniIspitPrikaziVM
            {
                Id=odjeljenje.Id,
                 PopravniIspiti = _db.PopravniIspit.Where(x=>x.OdjeljenjeId==odjeljenje.Id).Select(x => new PopravniIspitPrikaziVM.Row
                {
                    Id = x.PopravniIspitId,
                    Predmet = x.Predmet.Naziv,
                    Datum=x.DatumPopravnog,
                    BrojUcenikaKojiSuPolozili= _db.PopravniIspitUcenik.Where(y=>y.PopravniIspitId==x.PopravniIspitId && y.Bodovi>50).Count(),
                    BrojUcenikaNaPopravnom = _db.PopravniIspitUcenik.Where(y => y.PopravniIspitId == x.PopravniIspitId).Count(),

                 }).ToList()
            };
            return View(model);
        }

        public IActionResult Dodaj(int id)
        {
            Odjeljenje odjeljenje = _db.Odjeljenje.Where(x => x.Id == id).Include(x => x.Skola).
                Include(x => x.SkolskaGodina).FirstOrDefault();
            PopravniIspitDodajVM model = new PopravniIspitDodajVM
            {
                Id = odjeljenje.Id,
                Odjeljenje= odjeljenje.Oznaka,
                Datum=DateTime.Now,
                Predmet= _db.PredajePredmet.Where(y=>y.OdjeljenjeID==id).Select(y=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value=y.Predmet.Id.ToString(),
                    Text= y.Predmet.Naziv
                }).ToList(),
                Skola= odjeljenje.Skola.Naziv,
                SkolskaGodina= odjeljenje.SkolskaGodina.Naziv,
            };
            return View(model);
        }
        public IActionResult Snimi(PopravniIspitDodajVM model)
        {
            PopravniIspit novi = new PopravniIspit
            {
                OdjeljenjeId= model.Id,
                PredmetId= model.PredmetId,
                DatumPopravnog= model.Datum,
            };
            _db.Add(novi);
            _db.SaveChanges();

            //ucenici tog odjeljenje
            List<OdjeljenjeStavka> ucenici = _db.OdjeljenjeStavka.Where(x => x.OdjeljenjeId == novi.OdjeljenjeId).ToList();

            foreach(var i in ucenici)
            {
                //gdje je taj ucenik i na kojem predmetu ima 1
                var uceniciSaNegativnom = _db.DodjeljenPredmet.Where(x => x.OdjeljenjeStavkaId == i.Id && x.ZakljucnoKrajGodine == 1 && x.PredmetId == novi.PredmetId).ToList();
                var uceniciSaViseNegativnih= _db.DodjeljenPredmet.Where(x => x.OdjeljenjeStavkaId == i.Id && x.ZakljucnoKrajGodine == 1).ToList();
                PopravniIspitUcenik novinovi;
                if (uceniciSaViseNegativnih.Count()>=3 && uceniciSaViseNegativnih.Any(x=>x.PredmetId==novi.PredmetId))
                {
                     novinovi = new PopravniIspitUcenik
                    {
                        OdjeljenjeStavkaId = i.Id,
                        PopravniIspitId = novi.PopravniIspitId,
                        Bodovi = 0,
                        Pristupio=false
                    };
                    _db.Add(novinovi);
                }
                else if(uceniciSaNegativnom.Any())
                {
                     novinovi = new PopravniIspitUcenik
                    {
                        OdjeljenjeStavkaId = i.Id,
                        PopravniIspitId = novi.PopravniIspitId,
                        Bodovi = null,
                        Pristupio = false
                    };
                    _db.Add(novinovi);
                }
            }
            _db.SaveChanges();
            return Redirect("/PopravniIspit/Prikazi/" + novi.OdjeljenjeId);
        }

        public IActionResult Uredi(int id)
        {
            PopravniIspit pi = _db.PopravniIspit
               .Include(i => i.Odjeljenje)
               .Include(i => i.Odjeljenje.Skola)
               .Include(i => i.Odjeljenje.SkolskaGodina)
               .Include(i => i.Predmet)
               .Where(i => i.PopravniIspitId == id).FirstOrDefault();

            PopravniIspitUrediVM model = new PopravniIspitUrediVM
            {
                Id = pi.PopravniIspitId,
                Predmet = pi.Predmet.Naziv,
                Skola = pi.Odjeljenje.Skola.Naziv,
                SkolskaGodina = pi.Odjeljenje.SkolskaGodina.Naziv,
                Odjeljenje = pi.Odjeljenje.Oznaka,
                Datum = pi.DatumPopravnog

            };


            return View(model);
        }

    }
}