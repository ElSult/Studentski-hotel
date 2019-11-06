using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class izmjena : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RacunRestoran_Rezervacija_RezervacijaID",
                table: "RacunRestoran");

            migrationBuilder.DropForeignKey(
                name: "FK_RacunRestoran_StavkaRacuna_StavkaRacunaID",
                table: "RacunRestoran");

            migrationBuilder.DropIndex(
                name: "IX_RacunRestoran_RezervacijaID",
                table: "RacunRestoran");

            migrationBuilder.DropIndex(
                name: "IX_RacunRestoran_StavkaRacunaID",
                table: "RacunRestoran");

            migrationBuilder.DropColumn(
                name: "RezervacijaID",
                table: "RacunRestoran");

            migrationBuilder.DropColumn(
                name: "StavkaRacunaID",
                table: "RacunRestoran");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RezervacijaID",
                table: "RacunRestoran",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StavkaRacunaID",
                table: "RacunRestoran",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RacunRestoran_RezervacijaID",
                table: "RacunRestoran",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_RacunRestoran_StavkaRacunaID",
                table: "RacunRestoran",
                column: "StavkaRacunaID");

            migrationBuilder.AddForeignKey(
                name: "FK_RacunRestoran_Rezervacija_RezervacijaID",
                table: "RacunRestoran",
                column: "RezervacijaID",
                principalTable: "Rezervacija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RacunRestoran_StavkaRacuna_StavkaRacunaID",
                table: "RacunRestoran",
                column: "StavkaRacunaID",
                principalTable: "StavkaRacuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
