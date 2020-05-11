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
        private MojContext _context;

        public AjaxStavkeController(MojContext context)
        {
            _context = context;
        }

        public IActionResult Index(int IspitniTerminID)
        {
            AjaxUcenici vm = new AjaxUcenici()
            {
                IspitniTerminId = IspitniTerminID,
                ucenici = _context.ispitUcenici.Where(f => f.IspitniTerminId == IspitniTerminID)
                .Include(c=>c.SlusaPredmet)
                .Include(c => c.SlusaPredmet.UpisGodine)
                .Include(c => c.SlusaPredmet.UpisGodine.Student).Select(x => new AjaxUcenici.Row()
                {
                    ImeUcenika=x.SlusaPredmet.UpisGodine.Student.Ime + " " + x.SlusaPredmet.UpisGodine.Student.Prezime,
                    Ocjena = x.Ocjena,
                    Pristupio = x.Pristupio,
                    IspitUceniciId = x.Id

                }).ToList()
            };
            return PartialView(vm);
        }

        //public IActionResult NijePristupio(int IspitUceniciID)
        //{
        //    IspitUcenici p = _context.ispitUcenici.Where(x => x.Id == IspitUceniciID).FirstOrDefault();
        //    p.Pristupio = false;

        //    _context.Update(p);
        //    _context.SaveChanges();

        //    return Redirect("/IspitniTermin/Detalji?IspitniTerminID=" + p.IspitniTerminId);
        //}

        //public IActionResult Pristupio(int IspitUceniciID)
        //{
        //    IspitUcenici p = _context.ispitUcenici.Where(x => x.Id == IspitUceniciID).FirstOrDefault();
        //    p.Pristupio = true;

        //    _context.Update(p);
        //    _context.SaveChanges();

        //    return Redirect("/IspitniTermin/Detalji?IspitniTerminID=" + p.IspitniTerminId);
        //}

        [HttpGet]
        public IActionResult Detalji(int IspitUceniciID)
        {
            IspitUcenici p = _context.ispitUcenici.Where(x => x.Id == IspitUceniciID).Include(c => c.SlusaPredmet)
                .Include(c => c.SlusaPredmet.UpisGodine)
                .Include(c => c.SlusaPredmet.UpisGodine.Student).FirstOrDefault();
            

            AjaxOcjena vm = new AjaxOcjena()
            {
                IspitUcenikId = p.Id,
                ImeStudenta = p.SlusaPredmet.UpisGodine.Student.Ime + " " + p.SlusaPredmet.UpisGodine.Student.Prezime,
                Ocjena = p.Ocjena,
                 IspitniTerminId=p.IspitniTerminId
                
            };
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult Detalji(AjaxOcjena vm)
        {
            IspitUcenici p = _context.ispitUcenici.Where(x => x.Id ==  vm.IspitUcenikId ).Include(c => c.SlusaPredmet)
                .Include(c => c.SlusaPredmet.UpisGodine)
                .Include(c => c.SlusaPredmet.UpisGodine.Student).FirstOrDefault();

            p.Ocjena = vm.Ocjena;
            p.Pristupio = true;
            _context.Update(p);
            _context.SaveChanges();

            return Redirect("/IspitniTermin/Detalji?IspitniTerminID="+vm.IspitniTerminId);
        }

    }
}