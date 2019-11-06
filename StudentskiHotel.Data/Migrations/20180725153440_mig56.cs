using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class mig56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentskiUgovor_Obrok_ObrokID",
                table: "StudentskiUgovor");

            migrationBuilder.DropIndex(
                name: "IX_StudentskiUgovor_ObrokID",
                table: "StudentskiUgovor");

            migrationBuilder.DropColumn(
                name: "ObrokID",
                table: "StudentskiUgovor");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ObrokID",
                table: "StudentskiUgovor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentskiUgovor_ObrokID",
                table: "StudentskiUgovor",
                column: "ObrokID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentskiUgovor_Obrok_ObrokID",
                table: "StudentskiUgovor",
                column: "ObrokID",
                principalTable: "Obrok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
