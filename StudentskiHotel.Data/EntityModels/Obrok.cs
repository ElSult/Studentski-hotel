using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Obrok
    {
        public int Id { get; set; }
        [DataType(DataType.Time)] public TimeSpan VrijemePocetka { get; set; }

        [DataType(DataType.Time)] public TimeSpan VrijemeZavrsetka { get; set; }

        public int BrojObroka { get; set; }

        public int VrstaObrokaID { get; set; }
        [ForeignKey(nameof(VrstaObrokaID))]
        public VrstaObroka VrstaObroka { get; set; }

       

       
    }
}
