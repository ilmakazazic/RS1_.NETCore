using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class _6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ispitUcenici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IspitniTerminId = table.Column<int>(nullable: false),
                    Ocjena = table.Column<int>(nullable: true),
                    Pristupio = table.Column<bool>(nullable: false),
                    SlusaPredmetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ispitUcenici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ispitUcenici_ispitniTermin_IspitniTerminId",
                        column: x => x.IspitniTerminId,
                        principalTable: "ispitniTermin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ispitUcenici_SlusaPredmet_SlusaPredmetId",
                        column: x => x.SlusaPredmetId,
                        principalTable: "SlusaPredmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ispitUcenici_IspitniTerminId",
                table: "ispitUcenici",
                column: "IspitniTerminId");

            migrationBuilder.CreateIndex(
                name: "IX_ispitUcenici_SlusaPredmetId",
                table: "ispitUcenici",
                column: "SlusaPredmetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ispitUcenici");
        }
    }
}
