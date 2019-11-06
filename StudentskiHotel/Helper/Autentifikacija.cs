using Microsoft.AspNetCore.Http;
using StudentskiHotel.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiHotel.Web.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";
        public static void SetLogiraniKorisnik(this HttpContext context,Zaposlenik korisnik,bool snimiUCookie = false)
        {
            context.Session.Set(LogiraniKorisnik, korisnik);
        }
        public static Zaposlenik GetLogiraniKorisnik(this HttpContext context)
        {
            Zaposlenik korisnik = context.Session.Get<Zaposlenik>(LogiraniKorisnik);
            return korisnik;
        }
    }
}
