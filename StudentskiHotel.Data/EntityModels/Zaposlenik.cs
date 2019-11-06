using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Zaposlenik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string MaticniBroj { get; set; }
        public DateTime DatumRodenja { get; set; }
        public Gender Spol { get; set; }
        public int GradID { get; set; }
        [ForeignKey(nameof(GradID))]
        public Grad Grad { get; set; }
        public int StrucnaSpremaID { get; set; }
        [ForeignKey(nameof(StrucnaSpremaID))]
        public StrucnaSprema StrucnaSprema { get; set; }
        public TipZaposlenika Tip { get; set; }
        public int? KorisnickiNalogID { get; set; }
        [ForeignKey(nameof(KorisnickiNalogID))]
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
    public enum Gender
    {
        Musko = 1,
        Zensko = 2
    }
    public enum TipZaposlenika
    {
        Konobar = 1,
        Recepcioner = 2,
        Admin = 3
    }
}
