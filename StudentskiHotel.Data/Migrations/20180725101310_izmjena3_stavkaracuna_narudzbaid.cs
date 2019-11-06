using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class izmjena3_stavkaracuna_narudzbaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NarudzbaID",
                table: "StavkaRacuna",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StavkaRacuna_NarudzbaID",
                table: "StavkaRacuna",
                column: "NarudzbaID");

            migrationBuilder.AddForeignKey(
                name: "FK_StavkaRacuna_Narudzba_NarudzbaID",
                table: "StavkaRacuna",
                column: "NarudzbaID",
                principalTable: "Narudzba",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkaRacuna_Narudzba_NarudzbaID",
                table: "StavkaRacuna");

            migrationBuilder.DropIndex(
                name: "IX_StavkaRacuna_NarudzbaID",
                table: "StavkaRacuna");

            migrationBuilder.DropColumn(
                name: "NarudzbaID",
                table: "StavkaRacuna");
        }
    }
}
