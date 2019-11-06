using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class narudba_racunrestoran : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_RacunRestoran_RacunRestoranID",
                table: "Narudzba");

            migrationBuilder.AlterColumn<int>(
                name: "RacunRestoranID",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_RacunRestoran_RacunRestoranID",
                table: "Narudzba",
                column: "RacunRestoranID",
                principalTable: "RacunRestoran",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_RacunRestoran_RacunRestoranID",
                table: "Narudzba");

            migrationBuilder.AlterColumn<int>(
                name: "RacunRestoranID",
                table: "Narudzba",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_RacunRestoran_RacunRestoranID",
                table: "Narudzba",
                column: "RacunRestoranID",
                principalTable: "RacunRestoran",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
