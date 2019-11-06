using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int KantonID { get; set; }
        [ForeignKey(nameof(KantonID))]
        public Kanton Kanton { get; set; }
    }
}
