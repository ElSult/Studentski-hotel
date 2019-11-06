using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulZaposlenik.ViewModels;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.Controllers
{
    [Area("ModulZaposlenik")]
    [AutorizacijaAttribute(TipZaposlenika.Recepcioner)]
    public class StudentController : Controller
    {
        MyContext db = new MyContext();
      public IActionResult PrikaziStudent(string prezime)
        {
            PrikaziStudentVM Model = new PrikaziStudentVM();
            Model.studenti = db.Student.Include(x => x.Fakultet).
                Include(x => x.GodinaStudija).
                Include(x => x.Grad).Where(x=>x.Prezime.Contains(prezime) || prezime==null).ToList();
            return View(Model);
        }
        public IActionResult DodajStudent()
        {
            DodajStudentVM Model = new DodajStudentVM();

            List<SelectListItem> Fstavke = new List<SelectListItem>();
            Model.IsAktivan = true;
            Fstavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberi fakultet"
            });

            Fstavke.AddRange(db.Fakultet.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model.Fakulteti = Fstavke;

            List<SelectListItem> Gstavke = new List<SelectListItem>();

            Gstavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberi godinu studija",

            });
            Gstavke.AddRange(db.GodinaStudija.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv.ToString()
            }));

            Model.GodineStudija = Gstavke;

            List<SelectListItem> Ggrad = new List<SelectListItem>();
            Ggrad.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberi grad"
            });

            Ggrad.AddRange(db.Grad.Select(x=>new SelectListItem()
            {
                Value=x.Id.ToString(),
                Text=x.Naziv
            }));
            Model.Gradovi = Ggrad;
            return View(Model);
        }


        bool ProvjeriDuplikatMaticniBroj(string broj, int id)
        {
            if (db.Student.Any(x => x.MaticniBroj == broj && x.Id != id))
                return true;
            return false;
        }

        public IActionResult SnimiStudent(DodajStudentVM temp)
        {
           
            if(!ModelState.IsValid || ProvjeriDuplikatMaticniBroj(temp.MaticniBroj, temp.Id))
            {
                if (ProvjeriDuplikatMaticniBroj(temp.MaticniBroj, temp.Id))
                    ViewData["poruka"] = temp.MaticniBroj + " je već unesen!";

                List<SelectListItem> Fstavke = new List<SelectListItem>();

                Fstavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberi fakultet"
                });

                Fstavke.AddRange(db.Fakultet.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }));
                temp.Fakulteti = Fstavke;

                List<SelectListItem> Gstavke = new List<SelectListItem>();

                Gstavke.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberi godinu studija",

                });
                Gstavke.AddRange(db.GodinaStudija.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv.ToString()
                }));

                temp.GodineStudija = Gstavke;

                List<SelectListItem> Ggrad = new List<SelectListItem>();
                Ggrad.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberi grad"
                });

                Ggrad.AddRange(db.Grad.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }));
                temp.Gradovi = Ggrad;


                return View("UrediStudent", temp);

            }
            Student s;
            if(temp.Id==0)
            {
                s = new Student();
                db.Student.Add(s);
            }
            else
            {
                s = db.Student.Find(temp.Id);
            }


            s.Ime = temp.Ime;
            s.Prezime = temp.Prezime;
            s.KontaktTelefon = temp.KontaktTelefon;
            s.ImeOca = temp.ImeOca;
            s.MaticniBroj = temp.MaticniBroj;
            s.Spol = temp.Spol;
            s.DatumRodenja = temp.DatumRodenja;
            s.FakultetID = temp.FakultetID;
            s.GradID = temp.GradID;
            s.GodinaStudijaID = temp.GodinaStudijaID;
            s.IsAktivan = temp.IsAktivan;
            db.SaveChanges();
            return RedirectToAction("PrikaziStudent");
        }

        public IActionResult UrediStudent(int studentid )
        {
            DodajStudentVM Model = new DodajStudentVM();
            Student s = new Student();
            s = db.Student.Find(studentid);

            Model.Id = s.Id;
            Model.Ime = s.Ime;
            Model.Prezime = s.Prezime;
            Model.ImeOca = s.ImeOca;
            Model.Spol = s.Spol;
            Model.DatumRodenja = s.DatumRodenja;
            Model.KontaktTelefon = s.KontaktTelefon;
            Model.MaticniBroj = s.MaticniBroj;
            Model.FakultetID = s.FakultetID;
            Model.GradID = s.GradID;
            Model.GodinaStudijaID = s.GodinaStudijaID;
            Model.IsAktivan = s.IsAktivan;
            List<SelectListItem> Fstavke = new List<SelectListItem>();
            Fstavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberi fakultet"
            });
            Fstavke.AddRange(db.Fakultet.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model.Fakulteti = Fstavke;

            List<SelectListItem> Gstavke = new List<SelectListItem>();

            Gstavke.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberi godinu studija",

            });
            Gstavke.AddRange(db.GodinaStudija.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv.ToString()
            }));

            Model.GodineStudija = Gstavke;

            List<SelectListItem> Ggrad = new List<SelectListItem>();
            Ggrad.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberi grad"
            });

            Ggrad.AddRange(db.Grad.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }));
            Model.Gradovi = Ggrad;

           
            return View(Model);
        }
    }
}