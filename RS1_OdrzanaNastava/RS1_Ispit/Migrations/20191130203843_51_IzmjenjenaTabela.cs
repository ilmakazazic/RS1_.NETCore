using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class _51_IzmjenjenaTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoravniIspitUcenik_Ucenik_UcenikId",
                table: "PoravniIspitUcenik");

            migrationBuilder.RenameColumn(
                name: "UcenikId",
                table: "PoravniIspitUcenik",
                newName: "OdjeljenjeStavkaId");

            migrationBuilder.RenameIndex(
                name: "IX_PoravniIspitUcenik_UcenikId",
                table: "PoravniIspitUcenik",
                newName: "IX_PoravniIspitUcenik_OdjeljenjeStavkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoravniIspitUcenik_OdjeljenjeStavka_OdjeljenjeStavkaId",
                table: "PoravniIspitUcenik",
                column: "OdjeljenjeStavkaId",
                principalTable: "OdjeljenjeStavka",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoravniIspitUcenik_OdjeljenjeStavka_OdjeljenjeStavkaId",
                table: "PoravniIspitUcenik");

            migrationBuilder.RenameColumn(
                name: "OdjeljenjeStavkaId",
                table: "PoravniIspitUcenik",
                newName: "UcenikId");

            migrationBuilder.RenameIndex(
                name: "IX_PoravniIspitUcenik_OdjeljenjeStavkaId",
                table: "PoravniIspitUcenik",
                newName: "IX_PoravniIspitUcenik_UcenikId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoravniIspitUcenik_Ucenik_UcenikId",
                table: "PoravniIspitUcenik",
                column: "UcenikId",
                principalTable: "Ucenik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
