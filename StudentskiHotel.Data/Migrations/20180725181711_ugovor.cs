using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class ugovor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obrok_StudentskiUgovor_StudentskiUgovorID",
                table: "Obrok");

            migrationBuilder.DropIndex(
                name: "IX_Obrok_StudentskiUgovorID",
                table: "Obrok");

            migrationBuilder.DropColumn(
                name: "StudentskiUgovorID",
                table: "Obrok");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentskiUgovorID",
                table: "Obrok",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Obrok_StudentskiUgovorID",
                table: "Obrok",
                column: "StudentskiUgovorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obrok_StudentskiUgovor_StudentskiUgovorID",
                table: "Obrok",
                column: "StudentskiUgovorID",
                principalTable: "StudentskiUgovor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
