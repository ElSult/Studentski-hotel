using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Proizvod
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }

        public int? KategorijaID { get; set; }
        [ForeignKey(nameof(KategorijaID))]
        public KategorijaProizvoda KategorijaProizvoda { get; set; }
    }
}
