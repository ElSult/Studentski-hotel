using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using StudentskiHotel.Web.Areas.ModulRestoran.ViewModels;
using static StudentskiHotel.Web.Helper.Autorizacija;

namespace StudentskiHotel.Web.Areas.ModulRestoran.Controllers
{
    [Area("ModulRestoran")]
    [AutorizacijaAttribute(TipZaposlenika.Konobar)]
    public class StavkeRacunaController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult PrikaziStavke(int NarudzbaId, int KategorijaId)
        {
            PrikaziStavkeRacunaVM Model = new PrikaziStavkeRacunaVM();

            Model._kategorije = new List<SelectListItem>();
            Model._kategorije.AddRange(db.KategorijaProizvoda.Select(x => new SelectListItem()
            {

                Value = x.ID.ToString(),
                Text = x.NazivKategorije
            }));

            Model.KategorijaId = KategorijaId;
            Model.NarudzbaId = NarudzbaId;

            Model._proizvodi = db.Proizvod.Where(x=>x.KategorijaID == KategorijaId).ToList();

            Model._stavkeRacuna = db.StavkaRacuna.Include(x => x.Proizvod).Where(x => x.NarudzbaID == NarudzbaId).ToList();


            foreach(var Item in Model._stavkeRacuna)
            {
                Model.UkupniIznos += Item.Proizvod.Cijena * Item.Kolicina;
            }
          
            return PartialView(Model);
        }
        public IActionResult DodajStavke(int NarudzbaId, int KategorijaId, int ProizvodId)
        {
            StavkaRacuna temp = db.StavkaRacuna.Where(x => x.NarudzbaID == NarudzbaId && x.ProizvodID == ProizvodId).FirstOrDefault();

             if (temp is null)
            {
                temp = new StavkaRacuna();
                temp.NarudzbaID = NarudzbaId;
                temp.ProizvodID = ProizvodId;
                temp.Kolicina = 1;
                db.StavkaRacuna.Add(temp);

            }
            else
            {
                // ako stavka vec postoji u bazi
                temp.Kolicina++;
            }
             
            db.SaveChanges();

            return Redirect("/ModulRestoran/StavkeRacuna/PrikaziStavke?" +
            "KategorijaId=" + KategorijaId +
            "&NarudzbaId=" + NarudzbaId);
        }

        public IActionResult OduzmiStavke(int NarudzbaId, int KategorijaId, int ProizvodId)
        {
            StavkaRacuna temp = db.StavkaRacuna.Where(x => x.NarudzbaID == NarudzbaId && x.ProizvodID == ProizvodId).FirstOrDefault();

            if (temp != null) // stavka mora postojati ako se oduzima !!
            {


                if (temp.Kolicina > 1)
                {
                    temp.Kolicina--;
                }
                else // brisemo stavku jer joj je kolicina 0
                {
                    db.Remove(temp);
                }

                db.SaveChanges();
            }

            return Redirect("/ModulRestoran/StavkeRacuna/PrikaziStavke?" +
            "KategorijaId=" + KategorijaId +
            "&NarudzbaId=" + NarudzbaId);
        }
    }
}