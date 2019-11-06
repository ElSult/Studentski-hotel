using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class addKategorijaProizvoda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategorijaID",
                table: "Proizvod",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KategorijaProizvoda",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivKategorije = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaProizvoda", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KategorijaID",
                table: "Proizvod",
                column: "KategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_KategorijaProizvoda_KategorijaID",
                table: "Proizvod",
                column: "KategorijaID",
                principalTable: "KategorijaProizvoda",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_KategorijaProizvoda_KategorijaID",
                table: "Proizvod");

            migrationBuilder.DropTable(
                name: "KategorijaProizvoda");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_KategorijaID",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "KategorijaID",
                table: "Proizvod");
        }
    }
}
