using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class narudzbaDorada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Turist_TuristID",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_TuristID",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "TuristID",
                table: "Narudzba");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TuristID",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_TuristID",
                table: "Narudzba",
                column: "TuristID");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Turist_TuristID",
                table: "Narudzba",
                column: "TuristID",
                principalTable: "Turist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
