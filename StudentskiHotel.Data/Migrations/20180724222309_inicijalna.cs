using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AkademskaGodina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkGodina = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkademskaGodina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fakultet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakultet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GodinaStudija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GodinaStudija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KorisnickoIme = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NacinPlacanja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NacinPlacanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojSprata = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrucnaSprema",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrucnaSprema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usluga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaObroka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vrsta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaObroka", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaSobe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaSobe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kanton",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kanton_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojPasosa = table.Column<string>(nullable: true),
                    DrzavaID = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    KontaktTelefon = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turist_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkaRacuna",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaRacuna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkaRacuna_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obrok",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojObroka = table.Column<int>(nullable: false),
                    Satnica = table.Column<DateTime>(nullable: false),
                    VrstaObrokaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obrok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obrok_VrstaObroka_VrstaObrokaID",
                        column: x => x.VrstaObrokaID,
                        principalTable: "VrstaObroka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balkon = table.Column<bool>(nullable: false),
                    BrojSobe = table.Column<int>(nullable: false),
                    SpratID = table.Column<int>(nullable: false),
                    TV = table.Column<bool>(nullable: false),
                    VrstaSobeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soba_Sprat_SpratID",
                        column: x => x.SpratID,
                        principalTable: "Sprat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Soba_VrstaSobe_VrstaSobeID",
                        column: x => x.VrstaSobeID,
                        principalTable: "VrstaSobe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KantonID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grad_Kanton_KantonID",
                        column: x => x.KantonID,
                        principalTable: "Kanton",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRodenja = table.Column<DateTime>(nullable: false),
                    FakultetID = table.Column<int>(nullable: false),
                    GodinaStudijaID = table.Column<int>(nullable: false),
                    GradID = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    ImeOca = table.Column<string>(nullable: true),
                    KontaktTelefon = table.Column<string>(nullable: true),
                    MaticniBroj = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Fakultet_FakultetID",
                        column: x => x.FakultetID,
                        principalTable: "Fakultet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_GodinaStudija_GodinaStudijaID",
                        column: x => x.GodinaStudijaID,
                        principalTable: "GodinaStudija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRodenja = table.Column<DateTime>(nullable: false),
                    GradID = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    KorisnickiNalogID = table.Column<int>(nullable: true),
                    MaticniBroj = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<int>(nullable: false),
                    StrucnaSpremaID = table.Column<int>(nullable: false),
                    Tip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_KorisnickiNalog_KorisnickiNalogID",
                        column: x => x.KorisnickiNalogID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_StrucnaSprema_StrucnaSpremaID",
                        column: x => x.StrucnaSpremaID,
                        principalTable: "StrucnaSprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NacinPlacanjaID = table.Column<int>(nullable: false),
                    SobaID = table.Column<int>(nullable: false),
                    TuristID = table.Column<int>(nullable: false),
                    VrijemeDolaska = table.Column<DateTime>(nullable: false),
                    VrijemeOdlaska = table.Column<DateTime>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacija_NacinPlacanja_NacinPlacanjaID",
                        column: x => x.NacinPlacanjaID,
                        principalTable: "NacinPlacanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Soba_SobaID",
                        column: x => x.SobaID,
                        principalTable: "Soba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Turist_TuristID",
                        column: x => x.TuristID,
                        principalTable: "Turist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentskiUgovor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkademskaGodinaID = table.Column<int>(nullable: false),
                    BrojKartice = table.Column<int>(nullable: false),
                    MjesecnaNajamnina = table.Column<float>(nullable: false),
                    ObrokID = table.Column<int>(nullable: false),
                    SobaID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    UgovorZakljucenDana = table.Column<DateTime>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentskiUgovor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentskiUgovor_AkademskaGodina_AkademskaGodinaID",
                        column: x => x.AkademskaGodinaID,
                        principalTable: "AkademskaGodina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentskiUgovor_Obrok_ObrokID",
                        column: x => x.ObrokID,
                        principalTable: "Obrok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentskiUgovor_Soba_SobaID",
                        column: x => x.SobaID,
                        principalTable: "Soba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentskiUgovor_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentskiUgovor_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OdabranaUsluga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false),
                    UslugaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdabranaUsluga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdabranaUsluga_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdabranaUsluga_Usluga_UslugaID",
                        column: x => x.UslugaID,
                        principalTable: "Usluga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<float>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racun_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RacunRestoran",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RezervacijaID = table.Column<int>(nullable: false),
                    StavkaRacunaID = table.Column<int>(nullable: false),
                    UkupanIznos = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacunRestoran", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacunRestoran_Rezervacija_RezervacijaID",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacunRestoran_StavkaRacuna_StavkaRacunaID",
                        column: x => x.StavkaRacunaID,
                        principalTable: "StavkaRacuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grad_KantonID",
                table: "Grad",
                column: "KantonID");

            migrationBuilder.CreateIndex(
                name: "IX_Kanton_DrzavaID",
                table: "Kanton",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Obrok_VrstaObrokaID",
                table: "Obrok",
                column: "VrstaObrokaID");

            migrationBuilder.CreateIndex(
                name: "IX_OdabranaUsluga_RezervacijaID",
                table: "OdabranaUsluga",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_OdabranaUsluga_UslugaID",
                table: "OdabranaUsluga",
                column: "UslugaID");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_RezervacijaID",
                table: "Racun",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RacunRestoran_RezervacijaID",
                table: "RacunRestoran",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RacunRestoran_StavkaRacunaID",
                table: "RacunRestoran",
                column: "StavkaRacunaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_NacinPlacanjaID",
                table: "Rezervacija",
                column: "NacinPlacanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_SobaID",
                table: "Rezervacija",
                column: "SobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_TuristID",
                table: "Rezervacija",
                column: "TuristID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_ZaposlenikID",
                table: "Rezervacija",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Soba_SpratID",
                table: "Soba",
                column: "SpratID");

            migrationBuilder.CreateIndex(
                name: "IX_Soba_VrstaSobeID",
                table: "Soba",
                column: "VrstaSobeID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaRacuna_ProizvodID",
                table: "StavkaRacuna",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FakultetID",
                table: "Student",
                column: "FakultetID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GodinaStudijaID",
                table: "Student",
                column: "GodinaStudijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradID",
                table: "Student",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentskiUgovor_AkademskaGodinaID",
                table: "StudentskiUgovor",
                column: "AkademskaGodinaID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentskiUgovor_ObrokID",
                table: "StudentskiUgovor",
                column: "ObrokID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentskiUgovor_SobaID",
                table: "StudentskiUgovor",
                column: "SobaID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentskiUgovor_StudentID",
                table: "StudentskiUgovor",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentskiUgovor_ZaposlenikID",
                table: "StudentskiUgovor",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Turist_DrzavaID",
                table: "Turist",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_GradID",
                table: "Zaposlenik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_KorisnickiNalogID",
                table: "Zaposlenik",
                column: "KorisnickiNalogID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_StrucnaSpremaID",
                table: "Zaposlenik",
                column: "StrucnaSpremaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdabranaUsluga");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "RacunRestoran");

            migrationBuilder.DropTable(
                name: "StudentskiUgovor");

            migrationBuilder.DropTable(
                name: "Usluga");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "StavkaRacuna");

            migrationBuilder.DropTable(
                name: "AkademskaGodina");

            migrationBuilder.DropTable(
                name: "Obrok");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "NacinPlacanja");

            migrationBuilder.DropTable(
                name: "Soba");

            migrationBuilder.DropTable(
                name: "Turist");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "VrstaObroka");

            migrationBuilder.DropTable(
                name: "Fakultet");

            migrationBuilder.DropTable(
                name: "GodinaStudija");

            migrationBuilder.DropTable(
                name: "Sprat");

            migrationBuilder.DropTable(
                name: "VrstaSobe");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "StrucnaSprema");

            migrationBuilder.DropTable(
                name: "Kanton");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
