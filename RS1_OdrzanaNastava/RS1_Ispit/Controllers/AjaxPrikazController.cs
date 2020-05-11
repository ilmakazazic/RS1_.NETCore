using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class AjaxPrikazController : Controller
    {
        private MojContext _context;

        public AjaxPrikazController(MojContext context)
        {
            _context = context;
        }

        public IActionResult IndexAjaxPrikaz(int PopravniIspitID)
        {
            AjaxPrikazUceniciVM vm = new AjaxPrikazUceniciVM()
            {
                ucenici = _context.PoravniIspitUcenik.Where(w => w.PopravniIspitId == PopravniIspitID).Select(x => new AjaxPrikazUceniciVM.Row()
                {
                    PopravniIspitUcenikID = x.PoravniIspitUcenikId,
                    BrojUdnevniku = x.OdjeljenjeStavka.BrojUDnevniku,
                    Odjeljenje = x.OdjeljenjeStavka.Odjeljenje.Oznaka,
                    Ucenik = x.OdjeljenjeStavka.Ucenik.ImePrezime,
                    RezultatMaturskog = x.Rezultat,
                    Pristupio = x.Pristupio
                }).ToList()
            };

            return PartialView(vm);
        }
        public IActionResult UcenikJeOdsutan(int PopravniIspitID)
        {
            PoravniIspitUcenik piu = _context.PoravniIspitUcenik.Find(PopravniIspitID);
            piu.Pristupio = false;

            _context.PoravniIspitUcenik.Update(piu);
            _context.SaveChanges();
            return RedirectToAction("Detalji", "PopravniIspit", new { PopravniIspitID = piu.PopravniIspitId });
        }

        public IActionResult UcenikJePrisutan(int PopravniIspitID)
        {
            PoravniIspitUcenik piu = _context.PoravniIspitUcenik.Find(PopravniIspitID);
            piu.Pristupio = true;

            _context.PoravniIspitUcenik.Update(piu);
            _context.SaveChanges();
            return RedirectToAction("Detalji", "PopravniIspit", new { PopravniIspitID = piu.PopravniIspitId });
        }

        [HttpGet]
        public IActionResult Dodaj(int PopravniIspitUcenikID)
        {
            AjaxDodajVM vm = _context.PoravniIspitUcenik.Where(o => o.PoravniIspitUcenikId == PopravniIspitUcenikID).Select(x => new AjaxDodajVM()
            {
                popravniUcenikID=x.PoravniIspitUcenikId,
                Bodovi = x.Rezultat,
                Ucenik = x.OdjeljenjeStavka.Ucenik.ImePrezime,
                popravniID = x.PopravniIspitId
            }).First();
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(AjaxDodajVM vm)
        {
            PoravniIspitUcenik p = _context.PoravniIspitUcenik.Where(o => o.PoravniIspitUcenikId == vm.popravniUcenikID).FirstOrDefault();
            p.Rezultat = vm.Bodovi;

            _context.PoravniIspitUcenik.Update(p);
            _context.SaveChanges();
            return RedirectToAction("IndexAjaxPrikaz", "AjaxPrikaz", new { PopravniIspitID = vm.popravniID });
        }


    }
}