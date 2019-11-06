using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodenja { get; set; }
        public string ImeOca { get; set; }
        public string KontaktTelefon { get; set; }
        public string MaticniBroj { get; set; }
        public Gender Spol { get; set; }

        public int GodinaStudijaID { get; set; }
        [ForeignKey(nameof(GodinaStudijaID))]
        public GodinaStudija GodinaStudija { get; set; }

        public int GradID { get; set; }
        [ForeignKey(nameof(GradID))]
        public Grad Grad { get; set; }

        public int FakultetID { get; set; }
        [ForeignKey(nameof(FakultetID))]
        public Fakultet Fakultet { get; set; }

        public bool IsAktivan { get; set; }

    }
   
}
