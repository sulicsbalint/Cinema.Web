using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Web.Migrations
{
    public partial class cover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Movies");
        }
    }
}
