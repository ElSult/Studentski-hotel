using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentskiHotel.Data.Migrations
{
    public partial class nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UgovorObrok",
                columns: table => new
                {
                    UgovorObrokId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ObrokId = table.Column<int>(nullable: false),
                    UgovorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UgovorObrok", x => x.UgovorObrokId);
                    table.ForeignKey(
                        name: "FK_UgovorObrok_Obrok_ObrokId",
                        column: x => x.ObrokId,
                        principalTable: "Obrok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UgovorObrok_StudentskiUgovor_UgovorId",
                        column: x => x.UgovorId,
                        principalTable: "StudentskiUgovor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UgovorObrok_ObrokId",
                table: "UgovorObrok",
                column: "ObrokId");

            migrationBuilder.CreateIndex(
                name: "IX_UgovorObrok_UgovorId",
                table: "UgovorObrok",
                column: "UgovorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UgovorObrok");
        }
    }
}
