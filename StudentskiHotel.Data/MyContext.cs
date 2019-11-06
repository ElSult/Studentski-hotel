using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentskiHotel.Data.EntityModels;

namespace StudentskiHotel.Data
{
    public class MyContext : DbContext
    {
        public DbSet<AkademskaGodina> AkademskaGodina { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Fakultet> Fakultet { get; set; }
        public DbSet<GodinaStudija> GodinaStudija { get; set; }
        public DbSet<Kanton> Kanton { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<NacinPlacanja> NacinPlacanja { get; set; }
        public DbSet<Usluga> Usluga { get; set; }
        public DbSet<OdabranaUsluga> OdabranaUsluga { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<StavkaRacuna> StavkaRacuna { get; set; }
        public DbSet<RacunRestoran> RacunRestoran { get; set; }
        public DbSet<Sprat> Sprat { get; set; }
        public DbSet<VrstaSobe> VrstaSobe { get; set; }
        public DbSet<Soba> Soba { get; set; }
        public DbSet<StrucnaSprema> StrucnaSprema { get; set; }
        public DbSet<Zaposlenik> Zaposlenik { get; set; }
        public DbSet<VrstaObroka> VrstaObroka { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentskiUgovor> StudentskiUgovor { get; set; }
        public DbSet<Obrok> Obrok { get; set; }
        public DbSet<Turist> Turist { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<UgovorObrok> UgovorObrok { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<KategorijaProizvoda> KategorijaProizvoda { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=p1720.app.fit.ba;Database=p1720;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=p1720Korisnik;Password=Yj&jk522");
             optionsBuilder.UseSqlServer("Server=.; Database=StudentskiHotel; Trusted_Connection=true; MultipleActiveResultSets=true");
        }

        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezervacija>().HasOne(a => a.Zaposlenik).WithMany().HasForeignKey(a => a.ZaposlenikID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<StudentskiUgovor>().HasOne(a => a.Zaposlenik).WithMany().HasForeignKey(a => a.ZaposlenikID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Narudzba>().HasOne(a => a.Zaposlenik).WithMany().HasForeignKey(a => a.ZaposlenikID).OnDelete(DeleteBehavior.Restrict);

        }


    }
}


