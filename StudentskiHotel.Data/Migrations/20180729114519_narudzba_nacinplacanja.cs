using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class narudzba_nacinplacanja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_NacinPlacanja_NacinPlacanjaID",
                table: "Narudzba");

            migrationBuilder.AlterColumn<int>(
                name: "NacinPlacanjaID",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_NacinPlacanja_NacinPlacanjaID",
                table: "Narudzba",
                column: "NacinPlacanjaID",
                principalTable: "NacinPlacanja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_NacinPlacanja_NacinPlacanjaID",
                table: "Narudzba");

            migrationBuilder.AlterColumn<int>(
                name: "NacinPlacanjaID",
                table: "Narudzba",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_NacinPlacanja_NacinPlacanjaID",
                table: "Narudzba",
                column: "NacinPlacanjaID",
                principalTable: "NacinPlacanja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
