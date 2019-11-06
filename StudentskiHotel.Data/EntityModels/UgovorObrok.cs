using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentskiHotel.Data.EntityModels
{
    public class UgovorObrok
    {
        public int UgovorObrokId {get; set;}

        public int UgovorId { get; set; }
        [ForeignKey(nameof(UgovorId))]
        public StudentskiUgovor Ugovor { get; set; }

        public int ObrokId { get; set; }
        [ForeignKey(nameof(ObrokId))]
        public Obrok Obrok { get; set; }
    }
}
