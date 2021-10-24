using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LatoCruiser.Migrations
{
    public partial class LatoApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
