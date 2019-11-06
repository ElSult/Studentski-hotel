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
using StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels;
using StudentskiHotel.Web.Helper;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulZaposlenik.Controllers
{
    [Area("ModulZaposlenik")]
    [AutorizacijaAttribute(TipZaposlenika.Recepcioner)]
    public class StudentskiUgovorController : Controller
    {
        MyContext db = new MyContext();

        public IActionResult PrikaziStudentskiUgovor(int StudentId)
        {
            PrikaziStudentskiUgovorVM Model = new PrikaziStudentskiUgovorVM
            {
                ugovori = db.StudentskiUgovor.Where(x => x.StudentID == StudentId).
                    Include(x => x.Soba).
                    Include(x => x.Zaposlenik).
                    Include(x => x.AkademskaGodina).ToList(),
                studentId = StudentId
            };
            return View(Model);
        }

    
    
        public IActionResult DodajStudentskiUgovor (int studentID)
        {
            DodajStudentskiUgovorVM Model = new DodajStudentskiUgovorVM
            {
                StudentID = studentID,
                IsAktivan = true
            };
            List<SelectListItem> Sobe = new List<SelectListItem>();
            Sobe.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite broj sobe"
            });
            Sobe.AddRange(db.Soba.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.BrojSobe.ToString()

            }));
            Model.sobe = Sobe;

           

            List<SelectListItem> akgodine = new List<SelectListItem>();
            akgodine.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite akademsku godinu"
            });
            akgodine.AddRange(db.AkademskaGodina.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.AkGodina

            }));
            Model.akGodine = akgodine;

            return View(Model);
        }


        bool ProvjeriDuplokatKartica(int broj, int id)
        {
            if (db.StudentskiUgovor.Any(x => x.BrojKartice == broj && x.Id != id))
                return true;
            return false;
        }

        public bool ProvjeraSobe(int sobaId)
        {

            int brojac = 0;
            List<StudentskiUgovor> s = new List<StudentskiUgovor>();
            s = db.StudentskiUgovor.ToList();

            Soba soba = new Soba();
            soba = db.Soba.Include(x => x.VrstaSobe).Where(x => x.Id == sobaId).FirstOrDefault();

            if (soba == null)
                return true;

            foreach (StudentskiUgovor u in s)
            {
                if (u.SobaID == soba.Id && u.IsAktivan == true)
                    brojac++;
            }

            if (soba.VrstaSobe.Tip == "Jednokrevetna")
            {
                if (brojac < 1)
                    return true;//ako je dostupna vraca true
                else
                    return false;
            }
            if (soba.VrstaSobe.Tip == "Dvokrevetna")
            {
                if (brojac < 2)
                    return true;//ako je dostupna vraca true
                else
                    return false;
            }
            if (soba.VrstaSobe.Tip == "Trokrevetna")
            {
                if (brojac < 3)
                    return true;//ako je dostupna vraca true
                else
                    return false;
            }
            return false;//ako soba nema nijednu vrstu

        }

        public IActionResult SnimiStudentskiUgovor(DodajStudentskiUgovorVM temp)
        {

            Zaposlenik k = HttpContext.GetLogiraniKorisnik();

            int sessionID = k.Id;
            Zaposlenik z = db.Zaposlenik.Where(x => x.KorisnickiNalogID == sessionID).Single();
           

            if (!ModelState.IsValid || ProvjeriDuplokatKartica(temp.BrojKartice??0, temp.Id) || !ProvjeraSobe(temp.SobaID))
            {
                if (ProvjeriDuplokatKartica(temp.BrojKartice??0, temp.Id))
                     ViewData["poruka"] = "Broj kartice se već koristi!";

                if (!ProvjeraSobe(temp.SobaID))
                    ViewBag.sobaGreska = "Soba je zauzeta";

                List<SelectListItem> Sobe = new List<SelectListItem>();
                Sobe.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite broj sobe"
                });
                Sobe.AddRange(db.Soba.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.BrojSobe.ToString()

                }));
                temp.sobe = Sobe;

               
                List<SelectListItem> akgodine = new List<SelectListItem>();
                akgodine.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "Odaberite akademsku godinu"
                });
                akgodine.AddRange(db.AkademskaGodina.Select(x => new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.AkGodina

                }));
                temp.akGodine = akgodine;

               
              
                    return View("UrediStudentskiUgovor", temp);
            }
            StudentskiUgovor s;
            if(temp.Id==0)
            {
                s = new StudentskiUgovor();
                db.StudentskiUgovor.Add(s);
            }
            else
            {
                s=db.StudentskiUgovor.Find(temp.Id);
            }


            s.StudentID = temp.StudentID;
            s.BrojKartice = temp.BrojKartice??0;
            s.MjesecnaNajamnina = temp.MjesecnaNajamnina??0;
            s.UgovorZakljucenDana = temp.UgovorZakljucenDana;
            s.SobaID = temp.SobaID;
            s.IsAktivan = temp.IsAktivan;
            s.AkademskaGodinaID = temp.AkademskaGodinaID;
            s.ZaposlenikID = z.Id;
            db.SaveChanges();
            return RedirectToAction("PrikaziStudentskiUgovor", new { studentID = s.StudentID});
        }
        public IActionResult UrediStudentskiUgovor(int sid)
        {
            DodajStudentskiUgovorVM Model = new DodajStudentskiUgovorVM();
            StudentskiUgovor s = new StudentskiUgovor();
            s = db.StudentskiUgovor.Find(sid);

            Model.Id = s.Id;
            Model.AkademskaGodinaID = s.AkademskaGodinaID;
            Model.BrojKartice = s.BrojKartice;
            Model.MjesecnaNajamnina = s.MjesecnaNajamnina;
            Model.UgovorZakljucenDana = s.UgovorZakljucenDana;
            Model.SobaID = s.SobaID;
            Model.StudentID = s.StudentID;
            Model.IsAktivan = s.IsAktivan;
            List<SelectListItem> Sobe = new List<SelectListItem>();
            Sobe.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite broj sobe"
            });
            Sobe.AddRange(db.Soba.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.BrojSobe.ToString()

            }));
            Model.sobe = Sobe;

           

            List<SelectListItem> akgodine = new List<SelectListItem>();
            akgodine.Add(new SelectListItem()
            {
                Value = null,
                Text = "Odaberite akademsku godinu"
            });
            akgodine.AddRange(db.AkademskaGodina.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.AkGodina

            }));
            Model.akGodine = akgodine;

           
            return View(Model);
        }

       
    }

}