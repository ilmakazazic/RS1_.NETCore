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
                SkolskaGodina = _db.SkolskaGodina.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value=x.Id.ToString(),
                   Text= x.Naziv 
                }).ToList(),


                Skola = _db.Skola.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList(),


                Predmet = _db.Predmet.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList()

            };
      
            return View(model);
        }
        public IActionResult Prikazi(int skolskagodinaId, int skolaId, int predmetId)

        {
            var skolskaGodina = _db.SkolskaGodina.Where(x => x.Id == skolskagodinaId).FirstOrDefault();
            var skola = _db.Skola.Where(x => x.Id == skolaId).FirstOrDefault();
            var predmet = _db.Predmet.Where(x => x.Id == predmetId).FirstOrDefault();

            PopravniIspitPrikaziVM model = new PopravniIspitPrikaziVM
            {
                SkolskaGodinaId = skolskaGodina.Id,
                SkolaId = skola.Id,
                PredmetId = predmet.Id,
                PopravniIspiti = _db.PopravniIspit.Where(y => y.PredmetId == predmet.Id && y.SkolskaGodinaId == skolskaGodina.Id &&
                 y.SkolaId == skola.Id).Select(y => new PopravniIspitPrikaziVM.Row
                 {
                     PopravniIspitId= y.PopravniIspitId,
                     Datum = y.Datum,
                     Predmet= y.Predmet.Naziv,
                     BrojUcenikaNaPopravnomIspitu = _db.PopravniIspitUcenik.Where(z => z.PopravniIspitId == y.PopravniIspitId).Count(),
                     BrojUcenikaKojiSuPolozili=_db.PopravniIspitUcenik.Where(z=> z.PopravniIspitUcenikId==y.PopravniIspitId && z.RezultatPopravnogIspita>50).Count()
                 })
            .ToList()

            };
            return View(model);
        }
        public IActionResult Dodaj(int skolskagodinaId, int skolaId, int predmetId)
        {

            var skolskaGodina = _db.SkolskaGodina.Where(x => x.Id == skolskagodinaId).FirstOrDefault();
            var skola = _db.Skola.Where(x => x.Id == skolaId).FirstOrDefault();
            var predmet = _db.Predmet.Where(x => x.Id == predmetId).FirstOrDefault();

            PopravniIspitDodajVM model = new PopravniIspitDodajVM
            {
                Predmet = predmet.Naziv,
                Datum= DateTime.Now,
                Skola= skola.Naziv,
                SkolskaGodina =skolskaGodina.Naziv,
              Komisija1 = _db.Nastavnik.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
              {
                  Value = x.Id.ToString(),
                  Text = x.Ime  + " " + x.Prezime
              }).ToList(),
                Komisija2 = _db.Nastavnik.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Ime + " " + x.Prezime
                }).ToList(),
                Komisija3 = _db.Nastavnik.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Ime + " " + x.Prezime
                }).ToList(),
            };
            return View(model);
        }
        public IActionResult Snimi(PopravniIspitDodajVM model)
        {

            PopravniIspit novi = new PopravniIspit
            {
                PredmetId= model.PredmetId,
                SkolaId= model.SkolaId,
                SkolskaGodinaId= model.SkolskaGodinaId,
                Komisija1Id= model.Komisija1Id,
                Komisija2Id= model.Komisija2Id,
                Komisija3Id= model.Komisija3Id,
              
                Datum= DateTime.Now
            };

            _db.Add(novi);
            _db.SaveChanges();

            //ucenici koji imaju zakljuceno 1 na odabranom predmetu 
            List<DodjeljenPredmet> Ucenici = _db.DodjeljenPredmet.Where(x => x.PredmetId == novi.PredmetId &&
                                                                        x.OdjeljenjeStavka.Odjeljenje.SkolskaGodinaID == novi.SkolskaGodinaId &&
                                                                        x.OdjeljenjeStavka.Odjeljenje.SkolaID== novi.SkolaId &&
                                                                        x.ZakljucnoKrajGodine == 1
                                                                        ).Include(x => x.OdjeljenjeStavka).ToList();

            foreach (var u in Ucenici)
            {
                int brojjedinica = _db.DodjeljenPredmet.Where(x => x.OdjeljenjeStavkaId == u.OdjeljenjeStavkaId && x.ZakljucnoKrajGodine == 1).Count();

                //ima li tri ili vise jedinica, ako ima kod dodavanja ce u rezultat spasiti 0, ako ne nece nista
                if (brojjedinica >= 3)
                {
                    PopravniIspitUcenik noviucenik = new PopravniIspitUcenik
                    {
                        OdjeljenjeStavkaId = u.OdjeljenjeStavkaId,
                        PopravniIspitId = novi.PopravniIspitId,
                        PristupioIspitu = false,
                        RezultatPopravnogIspita = 0
                    };
                    _db.Add(noviucenik);
                }

                else
                {
                    PopravniIspitUcenik noviucenik = new PopravniIspitUcenik
                    {
                        OdjeljenjeStavkaId = u.OdjeljenjeStavkaId,
                        PopravniIspitId = novi.PopravniIspitId,
                        //PristupioIspitu = false
                    };
                    _db.Add(noviucenik);
                }
            }

            _db.SaveChanges();

            return Redirect("/PopravniIspit/Prikazi/?skolskagodinaId=" + novi.SkolskaGodinaId + "&skolaId="+ novi.SkolaId +"&predmetId="+ novi.PredmetId);
        }

        public IActionResult Uredi(int id)
        {
            PopravniIspit pi = _db.PopravniIspit.Where(x => x.PopravniIspitId == id).Include(x => x.SkolskaGodina).Include(x => x.Predmet
            ).Include(x => x.Skola).Include(x => x.Komisija1).Include(x => x.Komisija2).Include(x => x.Komisija3).FirstOrDefault();
            PopravniIspitUrediVM model = new PopravniIspitUrediVM
            {
                PopravniIspitId = pi.PopravniIspitId,
                Komisija1= pi.Komisija1.Ime + " " + pi.Komisija1.Prezime,
                Komisija2 = pi.Komisija2.Ime + " " + pi.Komisija2.Prezime,
                Komisija3 = pi.Komisija3.Ime + " " + pi.Komisija3.Prezime,
                Datum = pi.Datum,
                Skola= pi.Skola.Naziv,
                SkolskaGodina= pi.SkolskaGodina.Naziv,
                Predmet= pi.Predmet.Naziv

            };
            return View(model);
        }



    }
}