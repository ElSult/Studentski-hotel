using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Soba
    {
        public int Id { get; set; }
        public int BrojSobe { get; set; }
        public bool Balkon { get; set; }
        public bool TV { get; set; }
        public int SpratID { get; set; }
        [ForeignKey(nameof(SpratID))]
        public Sprat Sprat { get; set; }
        public int VrstaSobeID { get; set; }
        [ForeignKey(nameof(VrstaSobeID))]
        public VrstaSobe VrstaSobe { get; set; }
    }
}
