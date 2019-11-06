using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public DateTime VrijemeOdlaska { get; set; }
        

        public int NacinPlacanjaID { get; set; }
        [ForeignKey(nameof(NacinPlacanjaID))]
        public NacinPlacanja NacinPlacanja { get; set; }


        public int ZaposlenikID { get; set; }
        [ForeignKey(nameof(ZaposlenikID))]
        public Zaposlenik Zaposlenik { get; set; }

        public int KategorijaID { get; set; }
        [ForeignKey(nameof(KategorijaID))]
        public Kategorija Kategorija { get; set; }

        public int SobaID { get; set; }
        [ForeignKey(nameof(SobaID))]
        public Soba Soba { get; set; }

        public int TuristID { get; set; }
        [ForeignKey(nameof(TuristID))]
        public Turist Turist { get; set; }


    }
}
