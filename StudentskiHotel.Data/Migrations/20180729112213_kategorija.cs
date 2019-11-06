using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class kategorija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OdabranaUsluga_DodatnaUsluga_DodatnaUslugaID",
                table: "OdabranaUsluga");

            migrationBuilder.DropTable(
                name: "DodatnaUsluga");

            migrationBuilder.DropIndex(
                name: "IX_OdabranaUsluga_DodatnaUslugaID",
                table: "OdabranaUsluga");

            migrationBuilder.DropColumn(
                name: "Cijena",
                table: "OdabranaUsluga");

            migrationBuilder.DropColumn(
                name: "DodatnaUslugaID",
                table: "OdabranaUsluga");

            migrationBuilder.AddColumn<int>(
                name: "KategorijaID",
                table: "Rezervacija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KategorijaID",
                table: "Rezervacija",
                column: "KategorijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Kategorija_KategorijaID",
                table: "Rezervacija",
                column: "KategorijaID",
                principalTable: "Kategorija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Kategorija_KategorijaID",
                table: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacija_KategorijaID",
                table: "Rezervacija");

            migrationBuilder.DropColumn(
                name: "KategorijaID",
                table: "Rezervacija");

            migrationBuilder.AddColumn<float>(
                name: "Cijena",
                table: "OdabranaUsluga",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "DodatnaUslugaID",
                table: "OdabranaUsluga",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DodatnaUsluga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodatnaUsluga", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdabranaUsluga_DodatnaUslugaID",
                table: "OdabranaUsluga",
                column: "DodatnaUslugaID");

            migrationBuilder.AddForeignKey(
                name: "FK_OdabranaUsluga_DodatnaUsluga_DodatnaUslugaID",
                table: "OdabranaUsluga",
                column: "DodatnaUslugaID",
                principalTable: "DodatnaUsluga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
