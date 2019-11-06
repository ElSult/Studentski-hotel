using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class IzmjenaObroka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Satnica",
                table: "Obrok");

            migrationBuilder.RenameColumn(
                name: "DatumRezervacije",
                table: "Narudzba",
                newName: "DatumNarudzbe");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "VrijemePocetka",
                table: "Obrok",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "VrijemeZavrsetka",
                table: "Obrok",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VrijemePocetka",
                table: "Obrok");

            migrationBuilder.DropColumn(
                name: "VrijemeZavrsetka",
                table: "Obrok");

            migrationBuilder.RenameColumn(
                name: "DatumNarudzbe",
                table: "Narudzba",
                newName: "DatumRezervacije");

            migrationBuilder.AddColumn<DateTime>(
                name: "Satnica",
                table: "Obrok",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
