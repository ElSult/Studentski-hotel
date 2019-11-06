using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class dodatnaUsluga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
  

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "DodatnaUslugaID",
                table: "OdabranaUsluga");

        }
    }
}
