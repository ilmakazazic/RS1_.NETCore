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
    public class IspitniTerminController : Controller
    {

        private MojContext _context;

        public IspitniTerminController(MojContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            OdabirAngazovanVM vm = new OdabirAngazovanVM()
            {
                sviPredmeti = _context.Angazovan.Select(x => new OdabirAngazovanVM.RowPredmeta()
                {
                    NazivPredmeta = x.Predmet.Naziv,
                    PredmetId = x.PredmetId,
                    AngazovanId = x.Id,

                    AkademskaGodina = x.AkademskaGodina.Opis,
                    AkademskaGodinaId = x.AkademskaGodinaId,
                    Nastavnik = x.Nastavnik.Ime + " " + x.Nastavnik.Prezime,
                    NastavnikId = x.NastavnikId,
                    BrojPredmeta = _context.OdrzaniCas.Where(v=>v.AngazovaniId==x.Id).Count(),
                    BrojStudenata = _context.SlusaPredmet.Where(v => v.AngazovanId == x.Id).Count()
                }).ToList()

            };

            return View(vm);
        }


        public IActionResult Ispitni(int AngazovanID)
        {
            Angazovan ang = _context.Angazovan.Where(c => c.Id == AngazovanID).Include(x => x.Nastavnik)
                .Include(x => x.Predmet)
                .Include(x => x.AkademskaGodina).FirstOrDefault();

            IspitniVM vm = new IspitniVM
            {
                AkademskaGodina = ang.AkademskaGodina.Opis,
                Predmet = ang.Predmet.Naziv,
                Nastavnik = ang.Nastavnik.Ime + " " + ang.Nastavnik.Prezime,
                AngazovanId=AngazovanID,
                Ispiti = _context.ispitniTermin.Where(c => c.AngazovanId == AngazovanID).Select(b => new IspitniVM.Row()
                {
                     IspitniTerminId=b.Id,
                    DatumIspita = b.DatumIspita,
                    EvidentiranRezultat = false,
                    Nepolozeni = _context.SlusaPredmet.Where(c => c.AngazovanId == AngazovanID && c.Ocjena != null).Count(),
                    Prijavljeni = _context.SlusaPredmet.Where(c => c.AngazovanId == AngazovanID).Count()
                }).ToList()
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Dodaj(int AngazovanID)
        {
            Angazovan ang = _context.Angazovan.Where(c => c.Id == AngazovanID).Include(x => x.Nastavnik)
                .Include(x => x.Predmet)
                .Include(x => x.AkademskaGodina).FirstOrDefault();

            DodajIspitVM vm = new DodajIspitVM
            {
                AkademskaGodina = ang.AkademskaGodina.Opis,
                Predmet = ang.Predmet.Naziv,
                Nastavnik = ang.Nastavnik.Ime + " " + ang.Nastavnik.Prezime,
                DatumIspita = DateTime.Now,
                Napomena = null
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Dodaj(DodajIspitVM vm)
        {

            IspitniTermin noviIspit = new IspitniTermin()
            {
                AngazovanId = vm.AngazovanId,
                DatumIspita = vm.DatumIspita,
                Napomena = vm.Napomena

            };

            _context.ispitniTermin.Add(noviIspit);

            List<SlusaPredmet> ucenici = _context.SlusaPredmet.Where(v => v.AngazovanId == vm.AngazovanId).ToList();

            IspitUcenici dodajUcenike;
            foreach(var x in ucenici)
            {
                dodajUcenike = new IspitUcenici()
                {
                    SlusaPredmetId = x.Id,
                    IspitniTerminId = noviIspit.Id,
                    Pristupio = x.Ocjena != null ? true : false,
                    Ocjena = x.Ocjena

                };
                _context.ispitUcenici.Add(dodajUcenike);

            }


            _context.SaveChanges();
            return Redirect("/IspitniTermin/Ispitni?AngazovanID="+noviIspit.AngazovanId);
        }

        public IActionResult Detalji(int IspitniTerminID)
        {
            IspitniTermin ispit = _context.ispitniTermin.Where(c => c.Id == IspitniTerminID).Include(x => x.Angazovan)
                .Include(x => x.Angazovan.Nastavnik)
                .Include(x => x.Angazovan.Predmet)
                .Include(x => x.Angazovan.AkademskaGodina).First();


            DodajIspitVM vm = new DodajIspitVM
            {
                 IspitniTerminId=ispit.Id,
                AkademskaGodina = ispit.Angazovan.AkademskaGodina.Opis,
                Predmet = ispit.Angazovan.Predmet.Naziv,
                Nastavnik = ispit.Angazovan.Nastavnik.Ime + " " + ispit.Angazovan.Nastavnik.Prezime,
                AngazovanId = ispit.Angazovan.Id,
                DatumIspita = ispit.DatumIspita,
                Napomena = ispit.Napomena
            };
            return View(vm);
        }


    }
}