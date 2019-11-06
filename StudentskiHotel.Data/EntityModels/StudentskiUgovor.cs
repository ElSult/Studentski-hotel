using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class StudentskiUgovor
    {
        public int Id { get; set; }
        public int BrojKartice { get; set; }
        public DateTime UgovorZakljucenDana { get; set; }
        public float MjesecnaNajamnina { get; set; }

        public int StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }

        public int AkademskaGodinaID { get; set; }
        [ForeignKey(nameof(AkademskaGodinaID))]
        public AkademskaGodina AkademskaGodina { get; set; }

        public bool IsAktivan { get; set; }
       

        public int SobaID { get; set; }
        [ForeignKey(nameof(SobaID))]
        public Soba Soba { get; set; }

        public int ZaposlenikID { get; set; }
        [ForeignKey(nameof(ZaposlenikID))]
        public Zaposlenik Zaposlenik { get; set; }

        


    }
}
