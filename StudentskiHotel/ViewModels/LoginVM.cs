using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.ViewModels
{
    public class LoginVM
    {
        [StringLength(50,ErrorMessage ="Korisnicko ime mora sadrzavati minimalno 5 karaktera",MinimumLength =5)]
        public string KorisnickoIme { get; set; }
        [StringLength(50, ErrorMessage = "Lozinka mora sadrzavati minimalno 5 karaktera", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
        [DisplayName("Zapamti Lozinku")]
        public bool ZapamtiLozinku { get; set; }
    }
}
