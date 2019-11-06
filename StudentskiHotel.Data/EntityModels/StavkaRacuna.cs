using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class StavkaRacuna
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int ProizvodID { get; set; }
        [ForeignKey(nameof(ProizvodID))]
        public Proizvod Proizvod { get; set; }

        public int NarudzbaID { get; set; }
        [ForeignKey(nameof(NarudzbaID))]
        public Narudzba Narudzba{ get; set; }
    }
}
