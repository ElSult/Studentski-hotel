using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentskiHotel.Data.EntityModels
{
    public class Narudzba
    {
        public int Id { get; set; }

        public DateTime DatumNarudzbe { get; set; }

        public int? NacinPlacanjaID { get; set; }
        [ForeignKey(nameof(NacinPlacanjaID))]
        public NacinPlacanja NacinPlacanja { get; set; }

        public int ZaposlenikID { get; set; }
        [ForeignKey(nameof(ZaposlenikID))]
        public Zaposlenik Zaposlenik { get; set; }

        public int? RacunRestoranID { get; set; }
        [ForeignKey(nameof(RacunRestoranID))]
        public RacunRestoran RacunRestoran { get; set; }

        public bool Zavrsena { get; set; }
    }
}
