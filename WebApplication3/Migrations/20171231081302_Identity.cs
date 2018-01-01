using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication3.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TvShow",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TvShow_ApplicationUserId",
                table: "TvShow",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TvShow_AspNetUsers_ApplicationUserId",
                table: "TvShow",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TvShow_AspNetUsers_ApplicationUserId",
                table: "TvShow");

            migrationBuilder.DropIndex(
                name: "IX_TvShow_ApplicationUserId",
                table: "TvShow");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TvShow");
        }
    }
}
