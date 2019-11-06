using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class OdabranaUsluga
    {
        public int Id { get; set; }
     
        public int UslugaID { get; set; }
        [ForeignKey(nameof(UslugaID))]
        public Usluga Usluga { get; set; }
        public int RezervacijaID { get; set; }
        [ForeignKey(nameof(RezervacijaID))]
        public Rezervacija Rezervacija { get; set; }

    


    }
}
