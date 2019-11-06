using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class izmjena2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRezervacije = table.Column<DateTime>(nullable: false),
                    NacinPlacanjaID = table.Column<int>(nullable: false),
                    RacunRestoranID = table.Column<int>(nullable: false),
                    TuristID = table.Column<int>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzba_NacinPlacanja_NacinPlacanjaID",
                        column: x => x.NacinPlacanjaID,
                        principalTable: "NacinPlacanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_RacunRestoran_RacunRestoranID",
                        column: x => x.RacunRestoranID,
                        principalTable: "RacunRestoran",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Turist_TuristID",
                        column: x => x.TuristID,
                        principalTable: "Turist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_NacinPlacanjaID",
                table: "Narudzba",
                column: "NacinPlacanjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_RacunRestoranID",
                table: "Narudzba",
                column: "RacunRestoranID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_TuristID",
                table: "Narudzba",
                column: "TuristID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_ZaposlenikID",
                table: "Narudzba",
                column: "ZaposlenikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narudzba");
        }
    }
}
