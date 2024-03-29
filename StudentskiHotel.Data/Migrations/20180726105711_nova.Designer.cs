﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StudentskiHotel.Data;
using StudentskiHotel.Data.EntityModels;
using System;

namespace StudentskiHotel.Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20180726105711_nova")]
    partial class nova
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.AkademskaGodina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AkGodina");

                    b.HasKey("Id");

                    b.ToTable("AkademskaGodina");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Fakultet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Fakultet");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.GodinaStudija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("GodinaStudija");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KantonID");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("KantonID");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Kanton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DrzavaID");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Kanton");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.KorisnickiNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.HasKey("Id");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.NacinPlacanja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("NacinPlacanja");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumNarudzbe");

                    b.Property<int>("NacinPlacanjaID");

                    b.Property<int>("RacunRestoranID");

                    b.Property<int>("TuristID");

                    b.Property<int>("ZaposlenikID");

                    b.HasKey("Id");

                    b.HasIndex("NacinPlacanjaID");

                    b.HasIndex("RacunRestoranID");

                    b.HasIndex("TuristID");

                    b.HasIndex("ZaposlenikID");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Obrok", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojObroka");

                    b.Property<TimeSpan>("VrijemePocetka");

                    b.Property<TimeSpan>("VrijemeZavrsetka");

                    b.Property<int>("VrstaObrokaID");

                    b.HasKey("Id");

                    b.HasIndex("VrstaObrokaID");

                    b.ToTable("Obrok");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.OdabranaUsluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cijena");

                    b.Property<int>("RezervacijaID");

                    b.Property<int>("UslugaID");

                    b.HasKey("Id");

                    b.HasIndex("RezervacijaID");

                    b.HasIndex("UslugaID");

                    b.ToTable("OdabranaUsluga");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cijena");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Racun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumUplate");

                    b.Property<float>("Iznos");

                    b.Property<int>("RezervacijaID");

                    b.HasKey("Id");

                    b.HasIndex("RezervacijaID");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.RacunRestoran", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("UkupanIznos");

                    b.HasKey("Id");

                    b.ToTable("RacunRestoran");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NacinPlacanjaID");

                    b.Property<int>("SobaID");

                    b.Property<int>("TuristID");

                    b.Property<DateTime>("VrijemeDolaska");

                    b.Property<DateTime>("VrijemeOdlaska");

                    b.Property<int>("ZaposlenikID");

                    b.HasKey("Id");

                    b.HasIndex("NacinPlacanjaID");

                    b.HasIndex("SobaID");

                    b.HasIndex("TuristID");

                    b.HasIndex("ZaposlenikID");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Soba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Balkon");

                    b.Property<int>("BrojSobe");

                    b.Property<int>("SpratID");

                    b.Property<bool>("TV");

                    b.Property<int>("VrstaSobeID");

                    b.HasKey("Id");

                    b.HasIndex("SpratID");

                    b.HasIndex("VrstaSobeID");

                    b.ToTable("Soba");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Sprat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojSprata");

                    b.HasKey("Id");

                    b.ToTable("Sprat");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.StavkaRacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Kolicina");

                    b.Property<int>("NarudzbaID");

                    b.Property<int>("ProizvodID");

                    b.HasKey("Id");

                    b.HasIndex("NarudzbaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("StavkaRacuna");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.StrucnaSprema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("StrucnaSprema");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRodenja");

                    b.Property<int>("FakultetID");

                    b.Property<int>("GodinaStudijaID");

                    b.Property<int>("GradID");

                    b.Property<string>("Ime");

                    b.Property<string>("ImeOca");

                    b.Property<string>("KontaktTelefon");

                    b.Property<string>("MaticniBroj");

                    b.Property<string>("Prezime");

                    b.Property<int>("Spol");

                    b.HasKey("Id");

                    b.HasIndex("FakultetID");

                    b.HasIndex("GodinaStudijaID");

                    b.HasIndex("GradID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.StudentskiUgovor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AkademskaGodinaID");

                    b.Property<int>("BrojKartice");

                    b.Property<float>("MjesecnaNajamnina");

                    b.Property<int>("SobaID");

                    b.Property<int>("StudentID");

                    b.Property<DateTime>("UgovorZakljucenDana");

                    b.Property<int>("ZaposlenikID");

                    b.HasKey("Id");

                    b.HasIndex("AkademskaGodinaID");

                    b.HasIndex("SobaID");

                    b.HasIndex("StudentID");

                    b.HasIndex("ZaposlenikID");

                    b.ToTable("StudentskiUgovor");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Turist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojPasosa");

                    b.Property<int>("DrzavaID");

                    b.Property<string>("Ime");

                    b.Property<string>("KontaktTelefon");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Turist");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.UgovorObrok", b =>
                {
                    b.Property<int>("UgovorObrokId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ObrokId");

                    b.Property<int>("UgovorId");

                    b.HasKey("UgovorObrokId");

                    b.HasIndex("ObrokId");

                    b.HasIndex("UgovorId");

                    b.ToTable("UgovorObrok");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Usluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cijena");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Usluga");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.VrstaObroka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Vrsta");

                    b.HasKey("Id");

                    b.ToTable("VrstaObroka");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.VrstaSobe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tip");

                    b.HasKey("Id");

                    b.ToTable("VrstaSobe");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Zaposlenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRodenja");

                    b.Property<int>("GradID");

                    b.Property<string>("Ime");

                    b.Property<int?>("KorisnickiNalogID");

                    b.Property<string>("MaticniBroj");

                    b.Property<string>("Prezime");

                    b.Property<int>("Spol");

                    b.Property<int>("StrucnaSpremaID");

                    b.Property<int>("Tip");

                    b.HasKey("Id");

                    b.HasIndex("GradID");

                    b.HasIndex("KorisnickiNalogID");

                    b.HasIndex("StrucnaSpremaID");

                    b.ToTable("Zaposlenik");
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Grad", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Kanton", "Kanton")
                        .WithMany()
                        .HasForeignKey("KantonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Kanton", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Narudzba", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.NacinPlacanja", "NacinPlacanja")
                        .WithMany()
                        .HasForeignKey("NacinPlacanjaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.RacunRestoran", "RacunRestoran")
                        .WithMany()
                        .HasForeignKey("RacunRestoranID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Turist", "Turist")
                        .WithMany()
                        .HasForeignKey("TuristID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Obrok", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.VrstaObroka", "VrstaObroka")
                        .WithMany()
                        .HasForeignKey("VrstaObrokaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.OdabranaUsluga", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Rezervacija", "Rezervacija")
                        .WithMany()
                        .HasForeignKey("RezervacijaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Usluga", "Usluga")
                        .WithMany()
                        .HasForeignKey("UslugaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Racun", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Rezervacija", "Rezervacija")
                        .WithMany()
                        .HasForeignKey("RezervacijaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Rezervacija", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.NacinPlacanja", "NacinPlacanja")
                        .WithMany()
                        .HasForeignKey("NacinPlacanjaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Soba", "Soba")
                        .WithMany()
                        .HasForeignKey("SobaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Turist", "Turist")
                        .WithMany()
                        .HasForeignKey("TuristID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Soba", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Sprat", "Sprat")
                        .WithMany()
                        .HasForeignKey("SpratID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.VrstaSobe", "VrstaSobe")
                        .WithMany()
                        .HasForeignKey("VrstaSobeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.StavkaRacuna", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Student", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Fakultet", "Fakultet")
                        .WithMany()
                        .HasForeignKey("FakultetID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.GodinaStudija", "GodinaStudija")
                        .WithMany()
                        .HasForeignKey("GodinaStudijaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.StudentskiUgovor", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.AkademskaGodina", "AkademskaGodina")
                        .WithMany()
                        .HasForeignKey("AkademskaGodinaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Soba", "Soba")
                        .WithMany()
                        .HasForeignKey("SobaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Turist", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.UgovorObrok", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Obrok", "Obrok")
                        .WithMany()
                        .HasForeignKey("ObrokId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.StudentskiUgovor", "Ugovor")
                        .WithMany()
                        .HasForeignKey("UgovorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StudentskiHotel.Data.EntityModels.Zaposlenik", b =>
                {
                    b.HasOne("StudentskiHotel.Data.EntityModels.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StudentskiHotel.Data.EntityModels.KorisnickiNalog", "KorisnickiNalog")
                        .WithMany()
                        .HasForeignKey("KorisnickiNalogID");

                    b.HasOne("StudentskiHotel.Data.EntityModels.StrucnaSprema", "StrucnaSprema")
                        .WithMany()
                        .HasForeignKey("StrucnaSpremaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
