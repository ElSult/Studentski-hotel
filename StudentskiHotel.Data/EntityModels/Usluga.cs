using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Data.EntityModels
{
    public class Usluga
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
    }
}
