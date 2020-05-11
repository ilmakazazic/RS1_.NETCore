using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class PopravniIspitController : Controller
    {
        private MojContext _context;

        public PopravniIspitController(MojContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            OdabirPredmetaVM vm = new OdabirPredmetaVM()
            {
                Predmeti = _context.Predmet.Select(x => new OdabirPredmetaVM.Row()
                {
                    PredmetId = x.Id,
                    Naziv = x.Naziv,
                    Razred = x.Razred
                }).ToList()
            };
            return View(vm);
        }

        public IActionResult Prikaz(int PredmetID)
        {
            PrikazPopravnihVM vm = new PrikazPopravnihVM()
            {
                PredmetID = PredmetID,

                Popravni = _context.PopravniIspit.Where(e => e.PredmetId == PredmetID).Select(x => new PrikazPopravnihVM.Row()
                {
                    PopravniIspitId = x.PopravniIspitId,
                    DatumPopravnog = x.Datum,
                    Skola = x.Skola.Naziv,
                    SkolskaGodina = x.SkolskaGodina.Naziv,
                    BrojPolozenih = 0,
                    BrojUcenika = 0
                }).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Dodaj(int PredmetID)
        {
            List<Skola> skole = _context.Skola.ToList();
            List<SelectListItem> s = new List<SelectListItem>()
            {
                new SelectListItem(){ Value=string.Empty, Text="Odaberi skolu" }
            }.ToList();
            s.AddRange(skole.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }));

            List<SkolskaGodina> sg = _context.SkolskaGodina.ToList();
            List<SelectListItem> skolskeG = new List<SelectListItem>()
            {
                new SelectListItem(){ Value = string.Empty, Text="Odaberi skolsku godinu"}
            }.ToList();
            skolskeG.AddRange(sg.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));

            Predmet predmet = _context.Predmet.Find(PredmetID);
            DodajVM vm = new DodajVM()
            {
                PredmetID = PredmetID,
                Predmet = predmet.Naziv,
                Razred = predmet.Razred,
                DatumIspita = DateTime.Now,
                Skole = s,
                SkolskeGodine = skolskeG
            };
            return View(vm);
        }



        [HttpPost]
        public IActionResult Dodaj(DodajVM vm)
        {
            PopravniIspit pi = new PopravniIspit()
            {
                Datum = vm.DatumIspita,
                PredmetId = vm.PredmetID,
                SkolaId = vm.SkolaId,
                SkolskaGodinaId = vm.SkolskaGodinaId
            };

         
            _context.PopravniIspit.Add(pi);
            _context.SaveChanges();
            return RedirectToAction(nameof(Prikaz), new { PredmetID = vm.PredmetID });
        }

        public IActionResult Detalji(int PopravniIspitID)
        {
            DetaljiVM vm = _context.PopravniIspit.Where(p => p.PopravniIspitId == PopravniIspitID).Select(x => new DetaljiVM()
            {
                DatumIspita = x.Datum,
                Predmet = x.Predmet.Naziv,
                PopravniIspitID = x.PopravniIspitId,
                Razred = x.Predmet.Razred,
                Skola = x.Skola.Naziv,
                SkolskaGodina = x.SkolskaGodina.Naziv
            }).FirstOrDefault();

            return View(vm);
        }

    }
}

