using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Areas.ModulAdministrator.ViewModels
{
    public class PrikaziSobuVM
    {

        public List<Row> rows { get; set; }
        public int? brojSobe { get; set; }

        public class Row
        {
            public int Id { get; set; }
            public int? brojSobe { get; set; }
            public float Cijena { get; set; }
            public VrstaSobe VrstaSobe { get; set; }
            public Sprat Sprat { get; set; }
            public bool Balkon { get; set; }
            public bool TV { get; set; }
        }

    }
}
